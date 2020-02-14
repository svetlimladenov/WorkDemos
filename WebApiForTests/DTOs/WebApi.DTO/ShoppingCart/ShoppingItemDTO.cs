using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.DTO.ShoppingCart
{
    public class ShoppingItemDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Manufacturer { get; set; }
    }
}
