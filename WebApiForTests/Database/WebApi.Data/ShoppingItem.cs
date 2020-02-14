using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApi.Data
{
    public class ShoppingItem : BaseDbModel<int>
    {
        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }
         
        public string Manufacturer { get; set; }
    }
}
