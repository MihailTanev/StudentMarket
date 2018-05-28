using System;
using System.ComponentModel.DataAnnotations;

namespace StudentWebMarket.Models.Models
{
    public class Product
    {
        [Key]

        public int ProductId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public decimal OriginalPrice { get; set; }

        public decimal SalePrice { get; set; }

        public int? Year { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public string SellerId { get; set; }
        public virtual User Seller { get; set; }

        public int? ImageId { get; set; }
        public virtual Image Image { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int ConditionId { get; set; }
        public virtual Condition Condition { get; set; }

    }

}
