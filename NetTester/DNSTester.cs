using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetTester
{
    public class DNSTester
    {
        public static bool DnsTest()
        {
            try
            {
                System.Net.IPHostEntry ipHe = System.Net.Dns.GetHostByName("www.google.com");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
