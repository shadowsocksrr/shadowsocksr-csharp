using Shadowsocks.Controller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Shadowsocks.Encryption;

namespace Shadowsocks.Model
{
    public class UriVisitTime : IComparable
    {
        public DateTime visitTime;
        public string uri;
        public int index;

        public int CompareTo(object other)
        {
            if (!(other is UriVisitTime))
                throw new InvalidOperationException("CompareTo: Not a UriVisitTime");
            if (Equals(other))
                return 0;
            return visitTime.CompareTo(((UriVisitTime)other).visitTime);
        }

    }

    public enum PortMapType : int
    {
        Forward = 0,
        ForceProxy,
        RuleProxy
    }

    public enum ProxyRuleMode : int
    {
        Disable = 0,
        BypassLan,
        BypassLanAndChina,
        BypassLanAndNotChina,
        UserCustom = 16,
    }

    [Serializable]
    public class PortMapConfig
    {
        public bool enable;
        public PortMapType type;
        public string id;
        public string server_addr;
        public int server_port;
        public string remarks;
    }

    public class PortMapConfigCache
    {
        public PortMapType type;
        public string id;
        public Server server;
        public string server_addr;
        public int server_port;
    }

    [Serializable]
    public class ServerSubscribe
    {
        private static string DEFAULT_FEED_URL = "https://raw.githubusercontent.com/shadowsocksrr/breakwa11.github.io/master/free/freenodeplain.txt";
        //private static string OLD_DEFAULT_FEED_URL = "https://raw.githubusercontent.com/shadowsocksrr/breakwa11.github.io/master/free/freenode.txt";

        public string URL = DEFAULT_FEED_URL;
        public string Group;
        public UInt64 LastUpdateTime;
    }

    public class GlobalConfiguration
    {
        public static string config_password = "";
    }

    [Serializable()]
    class ConfigurationException : System.Exception
    {
        public ConfigurationException() : base() { }
        public ConfigurationException(string message) : base(message) { }
        public ConfigurationException(string message, System.Exception inner) : base(message, inner) { }
        protected ConfigurationException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
        { }
    }
    [Serializable()]
    class ConfigurationWarning : System.Exception
    {
        public ConfigurationWarning() : base() { }
        public ConfigurationWarning(string message) : base(message) { }
        public ConfigurationWarning(string message, System.Exception inner) : base(message, inner) { }
        protected ConfigurationWarning(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
        { }
    }

    [Serializable]
    public class Configuration
    {
        public List<Server> configs;
        public int index;
        public bool random;
        public int sysProxyMode;
        public bool shareOverLan;
        public int localPort;
        public string localAuthPassword;

        public string localDnsServer;
        public string dnsServer;
        public int reconnectTimes;
        public string balanceAlgorithm;
        public bool randomInGroup;
        public int TTL;
        public int connectTimeout;

        public int proxyRuleMode;

        public bool proxyEnable;
        public bool pacDirectGoProxy;
        public int proxyType;
        public string proxyHost;
        public int proxyPort;
        public string proxyAuthUser;
        public string proxyAuthPass;
        public string proxyUserAgent;

        public string authUser;
        public string authPass;

        public bool autoBan;
        public bool checkSwitchAutoCloseAll;
        public bool logEnable;
        public bool sameHostForSameTarget;

        public int keepVisitTime;

        public bool isHideTips;

        public bool nodeFeedAutoUpdate;
        public List<ServerSubscribe> serverSubscribes;

        public Dictionary<string, string> token = new Dictionary<string, string>();
        public Dictionary<string, PortMapConfig> portMap = new Dictionary<string, PortMapConfig>();

        private Dictionary<int, ServerSelectStrategy> serverStrategyMap = new Dictionary<int, ServerSelectStrategy>();
        private Dictionary<int, PortMapConfigCache> portMapCache = new Dictionary<int, PortMapConfigCache>();
        private LRUCache<string, UriVisitTime> uricache = new LRUCache<string, UriVisitTime>(180);

        private static string CONFIG_FILE = "gui-config.json";
        private static string CONFIG_FILE_BACKUP = "gui-config.json.backup";

        public static void SetPassword(string password)
        {
            GlobalConfiguration.config_password = password;
        }

        public static bool SetPasswordTry(string old_password, string password)
        {
            if (old_password != GlobalConfiguration.config_password)
                return false;
            return true;
        }

        public bool KeepCurrentServer(int localPort, string targetAddr, string id)
        {
            if (sameHostForSameTarget && targetAddr != null)
            {
                lock (serverStrategyMap)
                {
                    if (!serverStrategyMap.ContainsKey(localPort))
                        serverStrategyMap[localPort] = new ServerSelectStrategy();
                    ServerSelectStrategy serverStrategy = serverStrategyMap[localPort];

                    if (uricache.ContainsKey(targetAddr))
                    {
                        UriVisitTime visit = uricache.Get(targetAddr);
                        int index = -1;
                        for (int i = 0; i < configs.Count; ++i)
                        {
                            if (configs[i].id == id)
                            {
                                index = i;
                                break;
                            }
                        }
                        if (index >= 0 && visit.index == index && configs[index].enable)
                        {
                            uricache.Del(targetAddr);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public Server GetCurrentServer(int localPort, ServerSelectStrategy.FilterFunc filter, string targetAddr = null, bool cfgRandom = false, bool usingRandom = false, bool forceRandom = false)
        {
            lock (serverStrategyMap)
            {
                if (!serverStrategyMap.ContainsKey(localPort))
                    serverStrategyMap[localPort] = new ServerSelectStrategy();
                ServerSelectStrategy serverStrategy = serverStrategyMap[localPort];

                uricache.SetTimeout(keepVisitTime);
                uricache.Sweep();
                if (sameHostForSameTarget && !forceRandom && targetAddr != null && uricache.ContainsKey(targetAddr))
                {
                    UriVisitTime visit = uricache.Get(targetAddr);
                    if (visit.index < configs.Count && configs[visit.index].enable && configs[visit.index].ServerSpeedLog().ErrorContinurousTimes == 0)
                    {
                        uricache.Del(targetAddr);
                        return configs[visit.index];
                    }
                }
                if (forceRandom)
                {
                    int index;
                    if (filter == null && randomInGroup)
                    {
                        index = serverStrategy.Select(configs, this.index, balanceAlgorithm, delegate (Server server, Server selServer)
                        {
                            if (selServer != null)
                                return selServer.group == server.group;
                            return false;
                        }, true);
                    }
                    else
                    {
                        index = serverStrategy.Select(configs, this.index, balanceAlgorithm, filter, true);
                    }
                    if (index == -1) return GetErrorServer();
                    return configs[index];
                }
                else if (usingRandom && cfgRandom)
                {
                    int index;
                    if (filter == null && randomInGroup)
                    {
                        index = serverStrategy.Select(configs, this.index, balanceAlgorithm, delegate (Server server, Server selServer)
                        {
                            if (selServer != null)
                                return selServer.group == server.group;
                            return false;
                        });
                    }
                    else
                    {
                        index = serverStrategy.Select(configs, this.index, balanceAlgorithm, filter);
                    }
                    if (index == -1) return GetErrorServer();
                    if (targetAddr != null)
                    {
                        UriVisitTime visit = new UriVisitTime();
                        visit.uri = targetAddr;
                        visit.index = index;
                        visit.visitTime = DateTime.Now;
                        uricache.Set(targetAddr, visit);
                    }
                    return configs[index];
                }
                else
                {
                    if (index >= 0 && index < configs.Count)
                    {
                        int selIndex = index;
                        if (usingRandom)
                        {
                            for (int i = 0; i < configs.Count; ++i)
                            {
                                if (configs[selIndex].isEnable())
                                {
                                    break;
                                }
                                else
                                {
                                    selIndex = (selIndex + 1) % configs.Count;
                                }
                            }
                        }

                        if (targetAddr != null)
                        {
                            UriVisitTime visit = new UriVisitTime();
                            visit.uri = targetAddr;
                            visit.index = selIndex;
                            visit.visitTime = DateTime.Now;
                            uricache.Set(targetAddr, visit);
                        }
                        return configs[selIndex];
                    }
                    else
                    {
                        return GetErrorServer();
                    }
                }
            }
        }

        public void FlushPortMapCache()
        {
            portMapCache = new Dictionary<int, PortMapConfigCache>();
            Dictionary<string, Server> id2server = new Dictionary<string, Server>();
            Dictionary<string, int> server_group = new Dictionary<string, int>();
            foreach (Server s in configs)
            {
                id2server[s.id] = s;
                if (!string.IsNullOrEmpty(s.group))
                {
                    server_group[s.group] = 1;
                }
            }
            foreach (KeyValuePair<string, PortMapConfig> pair in portMap)
            {
                int key = 0;
                PortMapConfig pm = pair.Value;
                if (!pm.enable)
                    continue;
                if (id2server.ContainsKey(pm.id) || server_group.ContainsKey(pm.id) || pm.id == null || pm.id.Length == 0)
                { }
                else
                    continue;
                try
                {
                    key = int.Parse(pair.Key);
                }
                catch (FormatException)
                {
                    continue;
                }
                portMapCache[key] = new PortMapConfigCache
                {
                    type = pm.type,
                    id = pm.id,
                    server = id2server.ContainsKey(pm.id) ? id2server[pm.id] : null,
                    server_addr = pm.server_addr,
                    server_port = pm.server_port
                };
            }
            lock (serverStrategyMap)
            {
                List<int> remove_ports = new List<int>();
                foreach (KeyValuePair<int, ServerSelectStrategy> pair in serverStrategyMap)
                {
                    if (portMapCache.ContainsKey(pair.Key)) continue;
                    remove_ports.Add(pair.Key);
                }
                foreach (int port in remove_ports)
                {
                    serverStrategyMap.Remove(port);
                }
                if (!portMapCache.ContainsKey(localPort))
                    serverStrategyMap.Remove(localPort);
            }

            uricache.Clear();
        }

        public Dictionary<int, PortMapConfigCache> GetPortMapCache()
        {
            return portMapCache;
        }

        public static void CheckServer(Server server)
        {
            CheckPort(server.server_port);
            if (server.server_udp_port != 0)
                CheckPort(server.server_udp_port);
            try
            {
                CheckPassword(server.password);
            }
            catch (ConfigurationWarning cw)
            {
                server.password = "";
                MessageBox.Show(cw.Message, cw.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            CheckServer(server.server);
        }

        public Configuration()
        {
            index = 0;
            localPort = 1080;

            reconnectTimes = 2;
            keepVisitTime = 180;
            connectTimeout = 5;
            dnsServer = "";
            localDnsServer = "";

            balanceAlgorithm = "LowException";
            random = true;
            sysProxyMode = (int)ProxyMode.Global;
            proxyRuleMode = (int)ProxyRuleMode.BypassLanAndChina;

            nodeFeedAutoUpdate = true;

            serverSubscribes = new List<ServerSubscribe>()
            {
            };

            configs = new List<Server>()
            {
                GetDefaultServer()
            };
        }

        public void CopyFrom(Configuration config)
        {
            configs = config.configs;
            index = config.index;
            random = config.random;
            sysProxyMode = config.sysProxyMode;
            shareOverLan = config.shareOverLan;
            localPort = config.localPort;
            reconnectTimes = config.reconnectTimes;
            balanceAlgorithm = config.balanceAlgorithm;
            randomInGroup = config.randomInGroup;
            TTL = config.TTL;
            connectTimeout = config.connectTimeout;
            dnsServer = config.dnsServer;
            localDnsServer = config.localDnsServer;
            proxyEnable = config.proxyEnable;
            pacDirectGoProxy = config.pacDirectGoProxy;
            proxyType = config.proxyType;
            proxyHost = config.proxyHost;
            proxyPort = config.proxyPort;
            proxyAuthUser = config.proxyAuthUser;
            proxyAuthPass = config.proxyAuthPass;
            proxyUserAgent = config.proxyUserAgent;
            authUser = config.authUser;
            authPass = config.authPass;
            autoBan = config.autoBan;
            checkSwitchAutoCloseAll = config.checkSwitchAutoCloseAll;
            logEnable = config.logEnable;
            sameHostForSameTarget = config.sameHostForSameTarget;
            keepVisitTime = config.keepVisitTime;
            isHideTips = config.isHideTips;
            nodeFeedAutoUpdate = config.nodeFeedAutoUpdate;
            serverSubscribes = config.serverSubscribes;
        }

        public void FixConfiguration()
        {
            if (localPort == 0)
            {
                localPort = 1080;
            }
            if (keepVisitTime == 0)
            {
                keepVisitTime = 180;
            }
            if (portMap == null)
            {
                portMap = new Dictionary<string, PortMapConfig>();
            }
            if (token == null)
            {
                token = new Dictionary<string, string>();
            }
            if (connectTimeout == 0)
            {
                connectTimeout = 10;
                reconnectTimes = 2;
                TTL = 180;
                keepVisitTime = 180;
            }
            if (localAuthPassword == null || localAuthPassword.Length < 16)
            {
                localAuthPassword = randString(20);
            }

            Dictionary<string, int> id = new Dictionary<string, int>();
            if (index < 0 || index >= configs.Count) index = 0;
            foreach (Server server in configs)
            {
                if (id.ContainsKey(server.id))
                {
                    byte[] new_id = new byte[16];
                    Util.Utils.RandBytes(new_id, new_id.Length);
                    server.id = BitConverter.ToString(new_id).Replace("-", "");
                }
                else
                {
                    id[server.id] = 0;
                }
            }
        }

        private static string randString(int len)
        {
            string set = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-_";
            string ret = "";
            Random random = new Random();
            for (int i = 0; i < len; ++i)
            {
                ret += set[random.Next(set.Length)];
            }
            return ret;
        }

        public static Configuration LoadFile(string filename)
        {
            try
            {
                string configContent = File.ReadAllText(filename);
                return Load(configContent);
            }
            catch (Exception e)
            {
                if (!(e is FileNotFoundException))
                {
                    Console.WriteLine(e);
                }
                return new Configuration();
            }
        }

        public static Configuration Load()
        {
            return LoadFile(CONFIG_FILE);
        }

        public static void Save(Configuration config)
        {
            if (config.index >= config.configs.Count)
            {
                config.index = config.configs.Count - 1;
            }
            if (config.index < 0)
            {
                config.index = 0;
            }
            try
            {
                string jsonString = SimpleJson.SimpleJson.SerializeObject(config);
                if (GlobalConfiguration.config_password.Length > 0)
                {
                    IEncryptor encryptor = EncryptorFactory.GetEncryptor("aes-256-cfb", GlobalConfiguration.config_password, false);
                    byte[] cfg_data = UTF8Encoding.UTF8.GetBytes(jsonString);
                    byte[] cfg_encrypt = new byte[cfg_data.Length + 128];
                    int data_len = 0;
                    const int buffer_size = 32768;
                    byte[] input = new byte[buffer_size];
                    byte[] ouput = new byte[buffer_size + 128];
                    for (int start_pos = 0; start_pos < cfg_data.Length; start_pos += buffer_size)
                    {
                        int len = Math.Min(cfg_data.Length - start_pos, buffer_size);
                        int out_len;
                        Buffer.BlockCopy(cfg_data, start_pos, input, 0, len);
                        encryptor.Encrypt(input, len, ouput, out out_len);
                        Buffer.BlockCopy(ouput, 0, cfg_encrypt, data_len, out_len);
                        data_len += out_len;
                    }
                    jsonString = System.Convert.ToBase64String(cfg_encrypt, 0, data_len);
                }
                using (StreamWriter sw = new StreamWriter(File.Open(CONFIG_FILE, FileMode.Create)))
                {
                    sw.Write(jsonString);
                    sw.Flush();
                }

                if (File.Exists(CONFIG_FILE_BACKUP))
                {
                    DateTime dt = File.GetLastWriteTimeUtc(CONFIG_FILE_BACKUP);
                    DateTime now = DateTime.Now;
                    if ((now - dt).TotalHours > 4)
                    {
                        File.Copy(CONFIG_FILE, CONFIG_FILE_BACKUP, true);
                    }
                }
                else
                {
                    File.Copy(CONFIG_FILE, CONFIG_FILE_BACKUP, true);
                }
            }
            catch (IOException e)
            {
                Console.Error.WriteLine(e);
            }
        }

        public static Configuration Load(string config_str)
        {
            try
            {
                if (GlobalConfiguration.config_password.Length > 0)
                {
                    byte[] cfg_encrypt = System.Convert.FromBase64String(config_str);
                    IEncryptor encryptor = EncryptorFactory.GetEncryptor("aes-256-cfb", GlobalConfiguration.config_password, false);
                    byte[] cfg_data = new byte[cfg_encrypt.Length];
                    int data_len = 0;
                    const int buffer_size = 32768;
                    byte[] input = new byte[buffer_size];
                    byte[] ouput = new byte[buffer_size + 128];
                    for (int start_pos = 0; start_pos < cfg_encrypt.Length; start_pos += buffer_size)
                    {
                        int len = Math.Min(cfg_encrypt.Length - start_pos, buffer_size);
                        int out_len;
                        Buffer.BlockCopy(cfg_encrypt, start_pos, input, 0, len);
                        encryptor.Decrypt(input, len, ouput, out out_len);
                        Buffer.BlockCopy(ouput, 0, cfg_data, data_len, out_len);
                        data_len += out_len;
                    }
                    config_str = UTF8Encoding.UTF8.GetString(cfg_data, 0, data_len);
                }
            }
            catch
            {

            }
            try
            {
                Configuration config = SimpleJson.SimpleJson.DeserializeObject<Configuration>(config_str, new JsonSerializerStrategy());
                config.FixConfiguration();
                return config;
            }
            catch
            {
            }
            return null;
        }

        public static Server GetDefaultServer()
        {
            return new Server();
        }

        public bool isDefaultConfig()
        {
            if (configs.Count == 1 && configs[0].server == Configuration.GetDefaultServer().server)
                return true;
            return false;
        }

        public static Server CopyServer(Server server)
        {
            Server s = new Server();
            s.server = server.server;
            s.server_port = server.server_port;
            s.method = server.method;
            s.protocol = server.protocol;
            s.protocolparam = server.protocolparam ?? "";
            s.obfs = server.obfs;
            s.obfsparam = server.obfsparam ?? "";
            s.password = server.password;
            s.remarks = server.remarks;
            s.group = server.group;
            s.udp_over_tcp = server.udp_over_tcp;
            s.server_udp_port = server.server_udp_port;
            return s;
        }

        public static Server GetErrorServer()
        {
            Server server = new Server();
            server.server = "invalid";
            return server;
        }

        public static void CheckPort(int port)
        {
            if (port <= 0 || port > 65535)
            {
                throw new ConfigurationException(I18N.GetString("Port out of range"));
            }
        }

        private static void CheckPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ConfigurationWarning(I18N.GetString("Password are blank"));
                //throw new ConfigurationException(I18N.GetString("Password can not be blank"));
            }
        }

        private static void CheckServer(string server)
        {
            if (string.IsNullOrEmpty(server))
            {
                throw new ConfigurationException(I18N.GetString("Server IP can not be blank"));
            }
        }

        private class JsonSerializerStrategy : SimpleJson.PocoJsonSerializerStrategy
        {
            // convert string to int
            public override object DeserializeObject(object value, Type type)
            {
                if (type == typeof(Int32) && value.GetType() == typeof(string))
                {
                    return Int32.Parse(value.ToString());
                }
                return base.DeserializeObject(value, type);
            }
        }
    }

    [Serializable]
    public class ServerTrans
    {
        public long totalUploadBytes;
        public long totalDownloadBytes;

        void AddUpload(long bytes)
        {
            //lock (this)
            {
                totalUploadBytes += bytes;
            }
        }
        void AddDownload(long bytes)
        {
            //lock (this)
            {
                totalDownloadBytes += bytes;
            }
        }
    }

    [Serializable]
    public class ServerTransferTotal
    {
        private static string LOG_FILE = "transfer_log.json";

        public Dictionary<string, object> servers = new Dictionary<string, object>();
        private int saveCounter;
        private DateTime saveTime;

        public static ServerTransferTotal Load()
        {
            try
            {
                string config_str = File.ReadAllText(LOG_FILE);
                ServerTransferTotal config = new ServerTransferTotal();
                try
                {
                    if (GlobalConfiguration.config_password.Length > 0)
                    {
                        byte[] cfg_encrypt = System.Convert.FromBase64String(config_str);
                        IEncryptor encryptor = EncryptorFactory.GetEncryptor("aes-256-cfb", GlobalConfiguration.config_password, false);
                        byte[] cfg_data = new byte[cfg_encrypt.Length];
                        int data_len;
                        encryptor.Decrypt(cfg_encrypt, cfg_encrypt.Length, cfg_data, out data_len);
                        config_str = UTF8Encoding.UTF8.GetString(cfg_data, 0, data_len);
                    }
                }
                catch
                {

                }
                config.servers = SimpleJson.SimpleJson.DeserializeObject<Dictionary<string, object>>(config_str, new JsonSerializerStrategy());
                config.Init();
                return config;
            }
            catch (Exception e)
            {
                if (!(e is FileNotFoundException))
                {
                    Console.WriteLine(e);
                }
                return new ServerTransferTotal();
            }
        }

        public void Init()
        {
            saveCounter = 256;
            saveTime = DateTime.Now;
            if (servers == null)
                servers = new Dictionary<string, object>();
        }

        public static void Save(ServerTransferTotal config)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(File.Open(LOG_FILE, FileMode.Create)))
                {
                    string jsonString = SimpleJson.SimpleJson.SerializeObject(config.servers);
                    if (GlobalConfiguration.config_password.Length > 0)
                    {
                        IEncryptor encryptor = EncryptorFactory.GetEncryptor("aes-256-cfb", GlobalConfiguration.config_password, false);
                        byte[] cfg_data = UTF8Encoding.UTF8.GetBytes(jsonString);
                        byte[] cfg_encrypt = new byte[cfg_data.Length + 128];
                        int data_len;
                        encryptor.Encrypt(cfg_data, cfg_data.Length, cfg_encrypt, out data_len);
                        jsonString = System.Convert.ToBase64String(cfg_encrypt, 0, data_len);
                    }
                    sw.Write(jsonString);
                    sw.Flush();
                }
            }
            catch (IOException e)
            {
                Console.Error.WriteLine(e);
            }
        }

        public void Clear(string server)
        {
            lock (servers)
            {
                if (servers.ContainsKey(server))
                {
                    ((ServerTrans)servers[server]).totalUploadBytes = 0;
                    ((ServerTrans)servers[server]).totalDownloadBytes = 0;
                }
            }
        }

        public void AddUpload(string server, Int64 size)
        {
            lock (servers)
            {
                if (!servers.ContainsKey(server))
                    servers.Add(server, new ServerTrans());
                ((ServerTrans)servers[server]).totalUploadBytes += size;
            }
            if (--saveCounter <= 0)
            {
                saveCounter = 256;
                if ((DateTime.Now - saveTime).TotalMinutes > 10)
                {
                    lock (servers)
                    {
                        Save(this);
                        saveTime = DateTime.Now;
                    }
                }
            }
        }
        public void AddDownload(string server, Int64 size)
        {
            lock (servers)
            {
                if (!servers.ContainsKey(server))
                    servers.Add(server, new ServerTrans());
                ((ServerTrans)servers[server]).totalDownloadBytes += size;
            }
            if (--saveCounter <= 0)
            {
                saveCounter = 256;
                if ((DateTime.Now - saveTime).TotalMinutes > 10)
                {
                    lock (servers)
                    {
                        Save(this);
                        saveTime = DateTime.Now;
                    }
                }
            }
        }

        private class JsonSerializerStrategy : SimpleJson.PocoJsonSerializerStrategy
        {
            public override object DeserializeObject(object value, Type type)
            {
                if (type == typeof(Int64) && value.GetType() == typeof(string))
                {
                    return Int64.Parse(value.ToString());
                }
                else if (type == typeof(object))
                {
                    return base.DeserializeObject(value, typeof(ServerTrans));
                }
                return base.DeserializeObject(value, type);
            }
        }

    }
}
