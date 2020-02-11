using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Data
{
    public class ProductType : BaseDbModel<int>
    {
        public string Name { get; set; }
    }
}
