using Nancy.Hosting.Self;
using System;

namespace NancyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HostConfiguration hostConfigs = new HostConfiguration();
            hostConfigs.UrlReservations.CreateAutomatically = true;

            Uri uri = new Uri("http://localhost:1234/");
            NancyHost host = new NancyHost(hostConfigs, uri);
            host.Start();
            Console.WriteLine("rodando...");
            Console.ReadKey();
            host.Stop();
        }
    }
}
