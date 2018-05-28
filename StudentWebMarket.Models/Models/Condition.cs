using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentWebMarket.Models.Models
{
    public class Condition
    {
        [Key]
        public int ConditionId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
