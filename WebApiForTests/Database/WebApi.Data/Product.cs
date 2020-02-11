using System.Collections.Generic;

namespace WebApi.Data
{
    public class Product : BaseDbModel<int>
    {
        public Product()
        {
            this.Credits = new HashSet<Credit>();
        }
        public string Name { get; set; }

        public int? ProductTypeId { get; set; }

        public int? MinPrincipal { get; set; }

        public int? MaxPrincipal { get; set; }

        public int? Step { get; set; }

        public virtual ICollection<Credit> Credits { get; set; }
    }
}