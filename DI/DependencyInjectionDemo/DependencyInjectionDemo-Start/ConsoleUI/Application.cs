using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoLibrary;

namespace ConsoleUI
{
    public class Application : IApplication
    {
        private readonly IBusinessLogic businessLogic;

        public Application(IBusinessLogic businessLogic)
        {
            this.businessLogic = businessLogic;
        }

        public void Run()
        {
            this.businessLogic.ProcessData();
            Console.ReadLine();
        }
    }
}
