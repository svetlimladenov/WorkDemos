using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data
{
    [Table("nom.CreditStatus")]
    public class CreditStatus
    {
        public CreditStatus()
        {
            Credits = new HashSet<Credit>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Credit> Credits { get; set; }
    }
}