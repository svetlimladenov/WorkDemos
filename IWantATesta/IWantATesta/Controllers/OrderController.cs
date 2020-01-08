using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI;
using EasyNetQ;
using IWantATesla.Messages;

namespace IWantATesta.Web.Controllers
{
    public class OrderController : ApiController
    {
        // POST api/order
        public void Post([FromBody] TeslaOrder order)
        {
            //in real world inject the bus
            //this is creating connection to the rabbit mq 
            var messageBus = RabbitHutch.CreateBus("host=localhost");
            messageBus.Publish(order);
        }
    }
}