using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vianor.Infrastructure;
using Vianor.MS.Order.Contracts;

namespace Vianor.WebApi.Controllers
{
    public class OrderController : BaseController
    {
        public OrderController(IBusContainer busContainer) : base(busContainer)
        {
        }

        public IEnumerable<string> GetAllOrders()
        {
            var message = new GetAllOrdersMessage();
            var response = this.RequestAsync<GetAllOrdersMessage, GetAllOrdersResponseMessage>(message);
            return response.Result.OrderIds;
        }
    }
}
