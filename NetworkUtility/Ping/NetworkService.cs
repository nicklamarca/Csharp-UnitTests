
using NetworkUtility.DNS;
using System.Net.NetworkInformation;

namespace NetworkUtility.Ping
{
    public class NetworkService
    {
        private readonly IDNS _dns;

        public NetworkService(IDNS dns)
        {     
            _dns = dns;
        }

        public string SendPing()
        {
            //SearchDNS()
            var dnsSuccess = _dns.SendDNS();
            if (dnsSuccess)
            {
                return "Success: Ping Sent!";
            }
            else
            {
                return "Error: Ping Failed!";
            }
            //BuildPacket()
  
        }

        public int PingTimeout(int a, int b)
        {
            return a + b;
        }

        public DateTime LastPingDate()
        {
           return DateTime.Now;
        }

        public PingOptions GetPingOptions()
        {
            return new PingOptions()
            {
              DontFragment = true,
              Ttl = 128           
            };
        }

        public IEnumerable<PingOptions> MostRecentPings()
        {
            IEnumerable<PingOptions> pingOptions = new[]
            {
                new PingOptions()
                {
                    DontFragment = true,
                    Ttl = 1
                },
                 new PingOptions()
                {
                    DontFragment = true,
                    Ttl = 1
                },
                new PingOptions()
                {
                    DontFragment = false,
                    Ttl = 1
                }
            };

            return pingOptions;
        }

    }
}
