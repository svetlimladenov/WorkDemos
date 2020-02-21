using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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

        public async Task<IHttpActionResult> GetAllOrders()
        {
            var message = new GetAllOrdersMessage();
            var responseMessage = await this.RequestAsync<GetAllOrdersMessage, GetAllOrdersResponseMessage>(message);
            return Ok(responseMessage.OrderIds);
        }
    }
}
