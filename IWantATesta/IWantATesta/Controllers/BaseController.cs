using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using EasyNetQ;

namespace IWantATesta.Controllers
{
    public class BaseController
    {
        private IBus Bus { get; set; }

        protected Task PublishAsync<T>(T message)
            where T : BaseMessage
        {

            return Bus.PublishAsync(message);
        }
    }
}