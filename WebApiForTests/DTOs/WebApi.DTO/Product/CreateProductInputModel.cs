using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApi.DTO.Product
{
    public class CreateProductInputModel
    {
        [MinLength(3)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int? ProductTypeId { get; set; }

        [Required]
        public int? MinPrincipal { get; set; }

        [Required]
        public int? MaxPrincipal { get; set; }

        [Required]
        public int? Step { get; set; }
    }
}
