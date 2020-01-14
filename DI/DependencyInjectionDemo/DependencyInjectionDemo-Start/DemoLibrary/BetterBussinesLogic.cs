using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoLibrary.Utilities;

namespace DemoLibrary
{
    public class BetterBusinessLogic : IBusinessLogic
    {
        private readonly ILogger logger;
        private readonly IDataAccess dataAccess;

        public BetterBusinessLogic(ILogger logger, IDataAccess dataAccess)
        {
            this.logger = logger;
            this.dataAccess = dataAccess;
        }
        public void ProcessData()
        {

            this.logger.Log("Starting the processing of data.");
            Console.WriteLine("Better");
            Console.WriteLine("Processing the data");
            Console.WriteLine();
            this.dataAccess.LoadData();
            this.dataAccess.SaveData("ProcessedInfo");
            this.logger.Log("Finished processing of the data.");
        }
    }
}
