using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyNetQ;
using Vianor.Infrastructure.Messages;

namespace Vianor.Infrastructure
{
    public class MicroserviceBase : IMicroservice
    {
        protected IBus Bus { get; set; }

        public MicroserviceBase(IBus bus)
        {
            Bus = bus;
        }

        public virtual void Start()
        {
        }

        public virtual void Setup()
        {
        }

        public virtual void Stop()
        {
        }

        protected IDisposable Respond<TReq, TRes>(Func<TReq, TRes> handler, string methodName)
            where TReq : BaseMessage
            where TRes : ResponseMessage
        {
            return Bus.Respond<TReq, TRes>((message) =>
            {
                TRes responseResult = null;


                try
                {
                    responseResult = handler(message);
                }
                catch (Exception ex)
                {
                    //TODO: Log the exception
                    throw;
                }

                return responseResult;
            });
        }

        protected IDisposable RespondAsync<TReq, TRes>(Func<TReq, Task<TRes>> handler, string methodName)
            where TReq : BaseMessage
            where TRes : ResponseMessage
        {
            return Bus.RespondAsync<TReq, TRes>((request) =>
            {
                //TODO: Can log here

                var responseResult = handler(request);

                return responseResult;
            });
        }

        //TODO: Add Publish Subscribe Request Respond and Send Methods

    }
}
