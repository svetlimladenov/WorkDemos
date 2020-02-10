using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CoolService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CoolService" in both code and config file together.
    public class CoolService : ICoolService
    {
        public string DoWork()
        {
            return "Work"!;
        }

        public string GetCredits(DateTime dueDate)
        {
            return "credit credit credit";
        }
    }
}
