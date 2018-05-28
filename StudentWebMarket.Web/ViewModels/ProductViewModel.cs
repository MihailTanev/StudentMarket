using System;

namespace StudentWebMarket.Web.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public decimal? Price { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Product { get; set; }
        public int? ImageId { get; set; }

        public int CategoryID { get; set; }

    }
}