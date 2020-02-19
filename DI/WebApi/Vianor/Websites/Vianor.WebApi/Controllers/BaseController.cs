using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using EasyNetQ;
using Vianor.Infrastructure;

namespace Vianor.WebApi.Controllers
{
    public class BaseController : ApiController
    {   
        public IBus Bus { get; set; }

        public BaseController(IBusContainer busContainer)
        {
            this.Bus = busContainer.CreateBus();
        }

        public async Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest message)
            where TRequest : class 
            where TResponse : class
        {
            var response = await Bus.RequestAsync<TRequest, TResponse>(message);
            return response;
        }
    }
}