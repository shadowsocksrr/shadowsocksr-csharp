using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shadowsocks.Model;
using Shadowsocks.Util;

namespace test
{
    [TestClass]
    public class ServerTest
    {
        [TestMethod]
        public void TestServerFromSSR()
        {
            Server server = new Server();
            string nornameCase = "ssr://MTI3LjAuMC4xOjEyMzQ6YXV0aF9hZXMxMjhfbWQ1OmFlcy0xMjgtY2ZiOnRsczEuMl90aWNrZXRfYXV0aDpZV0ZoWW1KaS8_b2Jmc3BhcmFtPVluSmxZV3QzWVRFeExtMXZaUQ";

            server.ServerFromSSR(nornameCase, "");

            Assert.AreEqual<string>(server.server, "127.0.0.1");
            Assert.AreEqual<ushort>(server.server_port, 1234);
            Assert.AreEqual<string>(server.protocol, "auth_aes128_md5");
            Assert.AreEqual<string>(server.method, "aes-128-cfb");
            Assert.AreEqual<string>(server.obfs, "tls1.2_ticket_auth");
            Assert.AreEqual<string>(server.obfsparam, "breakwa11.moe");
            Assert.AreEqual<string>(server.password, "aaabbb");

            server = new Server();
            string normalCaseWithRemark = "ssr://MTI3LjAuMC4xOjEyMzQ6YXV0aF9hZXMxMjhfbWQ1OmFlcy0xMjgtY2ZiOnRsczEuMl90aWNrZXRfYXV0aDpZV0ZoWW1KaS8_b2Jmc3BhcmFtPVluSmxZV3QzWVRFeExtMXZaUSZyZW1hcmtzPTVyV0w2Sy1WNUxpdDVwYUg";

            server.ServerFromSSR(normalCaseWithRemark, "firewallAirport");

            Assert.AreEqual<string>(server.server, "127.0.0.1");
            Assert.AreEqual<ushort>(server.server_port, 1234);
            Assert.AreEqual<string>(server.protocol, "auth_aes128_md5");
            Assert.AreEqual<string>(server.method, "aes-128-cfb");
            Assert.AreEqual<string>(server.obfs, "tls1.2_ticket_auth");
            Assert.AreEqual<string>(server.obfsparam, "breakwa11.moe");
            Assert.AreEqual<string>(server.password, "aaabbb");

            Assert.AreEqual<string>(server.remarks, "测试中文");
            Assert.AreEqual<string>(server.group, "firewallAirport");
        }

        [TestMethod]
        public void TestHideServerName()
        {
            Dictionary<string, string> addrs = new Dictionary<string, string>();
            addrs.Add("127.0.0.1", "127.**.1");
            addrs.Add("2001:db8:85a3:8d3:1319:8a2e:370:7348", "2001:**:7348");
            addrs.Add("::1319:8a2e:370:7348", "**:7348");
            addrs.Add("::1", "**:1");

            foreach (string key in addrs.Keys)
            {
                string val = ServerName.HideServerAddr(key);
                Assert.AreEqual(addrs[key], val);
            }
        }

        [TestMethod]
        public void TestBadPortNumber()
        {
            Server server = new Server();

            string link = "ssr://MTI3LjAuMC4xOjgwOmF1dGhfc2hhMV92NDpjaGFjaGEyMDpodHRwX3NpbXBsZTplaWZnYmVpd3ViZ3IvP29iZnNwYXJhbT0mcHJvdG9wYXJhbT0mcmVtYXJrcz0mZ3JvdXA9JnVkcHBvcnQ9NDY0MzgxMzYmdW90PTQ2MDA3MTI4";
            try {
                server.ServerFromSSR(link, "");
            } catch (System.OverflowException e)
            {
                Console.Write(e.ToString());
            }

        }
    }
}
