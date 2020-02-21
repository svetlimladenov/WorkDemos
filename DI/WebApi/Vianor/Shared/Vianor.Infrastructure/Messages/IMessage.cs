using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vianor.Infrastructure.Messages
{
    public interface IMessage
    {
        string Version { get; set; }

        string Sender { get; set; }

        DateTime SentOnDate { get; set; }
    }
}
