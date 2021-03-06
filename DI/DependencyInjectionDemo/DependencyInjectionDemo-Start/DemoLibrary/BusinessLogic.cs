﻿using DemoLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class BusinessLogic : IBusinessLogic
    {
        private readonly ILogger logger;
        private readonly IDataAccess dataAccess;

        public BusinessLogic(ILogger logger, IDataAccess dataAccess)
        {
            this.logger = logger;
            this.dataAccess = dataAccess;
        }
        public void ProcessData()
        {
            

            this.logger.Log("Starting the processing of data.");
            Console.WriteLine("Processing the data");   
            this.dataAccess.LoadData();
            this.dataAccess.SaveData("ProcessedInfo");
            this.logger.Log("Finished processing of the data.");
        }
    }
}
