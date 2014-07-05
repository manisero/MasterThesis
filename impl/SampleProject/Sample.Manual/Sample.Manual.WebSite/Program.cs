using System;
using Nancy.Hosting.Self;

namespace Sample.Manual.WebSite
{
    class Program
    {
        static void Main(string[] args)
        {
            var uri = new Uri("http://localhost:1234");
            var configuration = new HostConfiguration
                {
                    UrlReservations = new UrlReservations
                        {
                            CreateAutomatically = true
                        }
                };

            using (var host = new NancyHost(configuration, uri))
            {
                host.Start();
                Console.ReadLine();
            }
        }
    }
}
