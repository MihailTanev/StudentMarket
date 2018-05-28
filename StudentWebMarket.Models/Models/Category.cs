using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentWebMarket.Models.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [MaxLength(10)]
        public string Name { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
