﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vianor.MS.Order.Contracts
{
    public class GetAllOrdersResponseMessage : ResponseMe
    {
        public IEnumerable<string> OrderIds { get; set; }
    }
}
