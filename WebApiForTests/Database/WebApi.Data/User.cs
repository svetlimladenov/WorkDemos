using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Data
{
    public class User : BaseDbModel<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Age { get; set; }

        public string PasswordHashed { get; set; }
    }
}
