using Shadowsocks.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Windows.Forms;

namespace Shadowsocks.Controller
{
    public class UpdateFreeNode
    {
        private const string UpdateURL = "https://raw.githubusercontent.com/shadowsocksrr/breakwa11.github.io/master/free/freenodeplain.txt";

        public event EventHandler NewFreeNodeFound;
        public string FreeNodeResult;
        public ServerSubscribe subscribeTask;
        public bool noitify;

        public const string Name = "ShadowsocksR";

        public void CheckUpdate(Configuration config, ServerSubscribe subscribeTask, bool use_proxy, bool noitify)
        {
            FreeNodeResult = null;
            this.noitify = noitify;
            try
            {
                WebClient http = new WebClient();
                http.Headers.Add("User-Agent",
                    String.IsNullOrEmpty(config.proxyUserAgent) ?
                    "Mozilla/5.0 (Windows NT 5.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/35.0.3319.102 Safari/537.36"
                    : config.proxyUserAgent);
                http.QueryString["rnd"] = Util.Utils.RandUInt32().ToString();
                if (use_proxy)
                {
                    WebProxy proxy = new WebProxy(IPAddress.Loopback.ToString(), config.localPort);
                    if (!string.IsNullOrEmpty(config.authPass))
                    {
                        proxy.Credentials = new NetworkCredential(config.authUser, config.authPass);
                    }
                    http.Proxy = proxy;
                }
                else
                {
                    http.Proxy = null;
                }
                //UseProxy = !UseProxy;
                this.subscribeTask = subscribeTask;
                string URL = subscribeTask.URL;
                
                //add support for tls1.2+
                if (URL.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | (SecurityProtocolType)3072 | SecurityProtocolType.Tls;
                }

                http.DownloadStringCompleted += http_DownloadStringCompleted;
                http.DownloadStringAsync(new Uri(URL != null ? URL : UpdateURL));
            }
            catch (Exception e)
            {
                Logging.LogUsefulException(e);
            }
        }

        private void http_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                string response = e.Result;
                FreeNodeResult = response;

                if (NewFreeNodeFound != null)
                {
                    NewFreeNodeFound(this, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                if (e.Error != null)
                {
                    Logging.Debug(e.Error.ToString());
                }
                Logging.Debug(ex.ToString());
                if (NewFreeNodeFound != null)
                {
                    NewFreeNodeFound(this, new EventArgs());
                }
                return;
            }
        }
    }

    public class UpdateSubscribeManager
    {
        private Configuration _config;
        private List<ServerSubscribe> _serverSubscribes;
        private UpdateFreeNode _updater;
        private string _URL;
        private bool _use_proxy;
        public bool _noitify;

        public void CreateTask(Configuration config, UpdateFreeNode updater, int index, bool use_proxy, bool noitify)
        {
            if (_config == null)
            {
                _config = config;
                _updater = updater;
                _use_proxy = use_proxy;
                _noitify = noitify;
                if (index < 0)
                {
                    _serverSubscribes = new List<ServerSubscribe>();
                    for (int i = 0; i < config.serverSubscribes.Count; ++i)
                    {
                        _serverSubscribes.Add(config.serverSubscribes[i]);
                    }
                }
                else if (index < _config.serverSubscribes.Count)
                {
                    _serverSubscribes = new List<ServerSubscribe>();
                    _serverSubscribes.Add(config.serverSubscribes[index]);
                }
                Next();
            }
        }

        public bool Next()
        {
            if (_serverSubscribes.Count == 0)
            {
                _config = null;
                return false;
            }
            else
            {
                _URL = _serverSubscribes[0].URL;
                _updater.CheckUpdate(_config, _serverSubscribes[0], _use_proxy, _noitify);
                _serverSubscribes.RemoveAt(0);
                return true;
            }
        }

        public string URL
        {
            get
            {
                return _URL;
            }
        }
    }
}
