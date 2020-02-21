using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using EasyNetQ;
using Vianor.Infrastructure;
using Vianor.Infrastructure.Messages;

namespace Vianor.WebApi.Controllers
{
    public class BaseController : ApiController
    {   
        public IBus Bus { get; set; }

        public BaseController(IBusContainer busContainer)
        {
            this.Bus = busContainer.GetBus();
        }

        public Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest message)
            where TRequest : BaseMessage 
            where TResponse : ResponseMessage
        {
            Task<TResponse> response;
            try
            {
                response = Bus.RequestAsync<TRequest, TResponse>(message);
            }
            catch (Exception ex)
            {
                //TODO: Used to log here
                throw;
            }

            return response;
        }
    }
}