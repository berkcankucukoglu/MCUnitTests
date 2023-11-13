using System.Net.NetworkInformation;

namespace FakeNetworkUtility.Ping
{
    public class NetworkService
    {
        public string SendPing()
        {
            //SearchDNS();
            //BuildPack();
            //Do something really important, then 
            return "Success: Ping Sent!";
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
