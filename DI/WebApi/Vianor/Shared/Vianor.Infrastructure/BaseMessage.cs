using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vianor.Infrastructure
{
    public abstract class BaseMessage
    {
        public string Sender { get; set; }

        public DateTime SentDate { get; set; }
    }
}
