using MockNetworkUtility.FakeDNS;
using System.Net.NetworkInformation;

namespace MockNetworkUtility.MockPing
{
    public class MockNetworkService
    {
        private readonly InterfaceDNS _dNS;

        public MockNetworkService(InterfaceDNS dNS)
        {
            _dNS = dNS;
        }
        public string SendPing()
        {
            var dnsSuccess = _dNS.SendDNS();
            if (dnsSuccess)
            {
                return "Success: Ping Sent!";
            }
            else
            {
                return "Fail: Ping Not Sent!";
            }
        }

        public int PingTimeout(int a, int b)
        {
            return a + b;
        }

        public DateTime LastPingDate()
        {
            return DateTime.Now;
        }

        public PingOptions PingOptions()
        {
            return new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };
        }

        public IEnumerable<PingOptions> MostRecentPings()
        {
            IEnumerable<PingOptions> pingOptions = new[]
            {
                new PingOptions() {
                    DontFragment= true,
                    Ttl= 1,
                },
                new PingOptions() {
                    DontFragment= true,
                    Ttl= 1,
                },
                new PingOptions() {
                    DontFragment= true,
                    Ttl= 1,
                }
            };
            return pingOptions;
        }
    }
}
