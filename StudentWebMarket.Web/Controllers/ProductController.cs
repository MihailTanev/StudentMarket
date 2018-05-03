using StudentWebMarket.Web.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace StudentWebMarket.Web.Controllers
{
    public class ProductController : BaseController
    {
        public ActionResult ProductDetails(int? id)
        {
            var model = this.db.Products.All().Where(g => g.ProductId == id)
                .Select(g => new ProductDetailsViewModel
                {
                    ProductId = g.ProductId,
                    OriginalPrice = g.OriginalPrice,
                    SalePrice = g.SalePrice,
                    Year = g.Year,
                    CreatedOn = g.CreatedOn,
                    RegistrationDate = g.Seller.RegistrationDate,
                    Name = g.Name,
                    UserPhoto=g.Seller.UserPhoto,
                    Condition = g.Condition.Name,
                    CategoryName = g.Category.Name,
                    ImageId = g.Image.ImageId,
                    SellerFirstName = g.Seller.FirstName,
                    SellerLastName = g.Seller.LastName,
                    SellerEmail = g.Seller.Email,
                    SellerPhone = g.Seller.PhoneNumber,
                    Description = g.Description
                }).FirstOrDefault();
            return View(model);
        }
    }
}