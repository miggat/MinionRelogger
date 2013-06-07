using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace MinionReloggerLib.Helpers.MyIP
{
    public static class GetMyIP
    {
        public static IPAddress GetMyCurrentIPAddress()
        {
            try
            {
                var req = new HTTPGet();
                req.Request("http://checkip.dyndns.org");
                string[] a = req.ResponseBody.Split(':');
                string a2 = a[1].Substring(1);
                string[] a3 = a2.Split('<');
                string a4 = a3[0];
                return IPAddress.Parse(a4);
            }
            catch // YES IM FUCKING LAZY OK CBA WITH THIS ONE THX
            {
                return new IPAddress(new byte[] {255, 255, 255, 255});
            }
        }

        public static bool IsMyAddress(IPAddress toCheck)
        {
            return toCheck.Equals(GetMyCurrentIPAddress());
        }

        public static bool ListContainsMyIPAddress(List<IPAddress> listOfAddresses)
        {
            IPAddress myAddress = GetMyCurrentIPAddress();
            return listOfAddresses.Any(ip => ip.Equals(myAddress));
        }
    }
}