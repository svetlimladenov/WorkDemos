using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vianor.Infrastructure.Messages
{
    public class ResponseMessage : BaseMessage, IResponseMessage
    {
        private string _error;
        public bool IsOk { get; set; }

        public string Error
        {
            get { return _error; }
            set
            {
                _error = value;
                IsOk = string.IsNullOrEmpty(value);
            }
        }

        public List<int> ValidationErrors { get; set; }

        public bool HasValidationErrors => ValidationErrors.Count > 0;

        public Exception Exception { get; set; }

        public bool HasException => Exception != null;

        public ResponseMessage()
        {
            Version = "1.0.0";
            Sender = string.Empty;
            SentOnDate = DateTime.UtcNow;
            IsOk = true;
            ValidationErrors = new List<int>();
        }
    }
}
