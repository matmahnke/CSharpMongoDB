using Nancy.Hosting.Self;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyConsole
{
    class Program
    {
        public static void Main(string[] args)
        {
            HostConfiguration hostConfigs = new HostConfiguration();
            hostConfigs.UrlReservations.CreateAutomatically = true;

            Uri uri = new Uri("http://localhost:1234/");
            NancyHost host = new NancyHost(hostConfigs, uri);
            host.Start();
            //MyRequest.post().Wait();
            MyRequest.Request();
            Console.ReadKey();
            host.Stop();
        }
    }
}
