using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Zza.Services;

namespace Zza.ConsoleHost
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                ServiceHost host = new ServiceHost(typeof(ZzaService));
                host.Open();
                Console.WriteLine("Hit any key to exit");
                Console.Read();
                host.Close();
            }
            catch (Exception ex)
            {
                //log it
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
