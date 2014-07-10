using System;
using Nancy.Hosting.Self;

namespace Sample.WebSite
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

                Console.WriteLine("Nancy host started at: {0}", uri);
                Console.ReadKey();
            }
        }
    }
}
