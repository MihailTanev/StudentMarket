using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentWebMarket.Web.ViewModels
{
    public class ProductDetailsViewModel
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }

        public decimal OriginalPrice { get; set; }
        public decimal SalePrice { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string Condition { get; set; }
        public byte[] UserPhoto { get; set; }

        public string Name { get; set; }
        public int? Year { get; set; }
        public string CategoryName { get; set; }
        public int? ImageId { get; set; }
        public string SellerName { get; set; }
        public string SellerFirstName { get; set; }
        public string SellerLastName { get; set; }
        public string SellerEmail { get; set; }
        public string City { get; set; }
        public string SellerPhone { get; set; }
        public string Description { get; set; }
    }
}