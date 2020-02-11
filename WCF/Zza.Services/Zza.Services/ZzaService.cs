using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Zza.Data;
using Zza.Entities;

namespace Zza.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class ZzaService : IZzaService, IDisposable
    {
        private readonly ZzaDbContext context = new ZzaDbContext();
        public List<Product> GetProducts()
        {
            return this.context.Products.ToList();
        }

        public List<Customer> GetCustomers()
        {
            return this.context.Customers.ToList();
        }

        [OperationBehavior(TransactionScopeRequired = true )]
        public void SubmitOrder(Order order)
        {
            this.context.Orders.Add(order);
            foreach (var item in order.OrderItems)
            {
                this.context.OrderItems.Add(item);
            }

            this.context.SaveChanges();
        }
        
        public void Dispose()
        {
            context?.Dispose();
        }
    }
}
