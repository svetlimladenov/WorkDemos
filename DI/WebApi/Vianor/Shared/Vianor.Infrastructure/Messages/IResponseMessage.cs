using System;
using System.Collections.Generic;

namespace Vianor.Infrastructure.Messages
{
    public interface IResponseMessage : IMessage
    {
        bool IsOk { get; set; }

        string Error { get; set; }

        List<int> ValidationErrors { get; set; }

        bool HasValidationErrors { get; }

        Exception Exception { get; set; }

        bool HasException { get; }
    }
}