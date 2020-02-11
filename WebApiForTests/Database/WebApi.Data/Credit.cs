using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Data
{
    public class Credit : BaseDbModel<int>
    {
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public decimal Limit { get; set; }

        public int? Period { get; set; }

        public int? CreditStatusId { get; set; }

        public virtual CreditStatus CreditStatus { get; set; }

    }
}
