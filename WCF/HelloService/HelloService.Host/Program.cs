using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
namespace HelloService.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(HelloService)))
            {
                host.Open();
                Console.WriteLine($"Host started @ {DateTime.Now}");
                Console.WriteLine("Service running at: {0}", String.Join(", ", host.BaseAddresses));
                Console.ReadLine();
            }
        }
    }
}
