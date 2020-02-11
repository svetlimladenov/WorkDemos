using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.DTO.Product
{
    public class ProductDTO
    {
        public string Name { get; set; }

        public int? ProductTypeId { get; set; }

        public int? MinPrincipal { get; set; }

        public int? MaxPrincipal { get; set; }

        public int? Step { get; set; }
    }
}
