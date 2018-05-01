using StudentWebMarket.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentWebMarket.Web.Controllers
{
    public class HomeController : BaseController
    {
        private IQueryable<ProductViewModel> GetAllProducts()
        {
            var products = this.db.Products.All().Select(x => new ProductViewModel
            {
                Id = x.ProductId,
                ImageId = x.Image.ImageId,
                Product = x.Name,
                CreatedOn = x.CreatedOn,
                Price = x.SalePrice,
                CategoryID = x.CategoryId,
            }).OrderByDescending(x => x.CreatedOn);
            return products;
        }
        public ActionResult Index()
        {
            var viewModel = GetAllProducts();
            return View(viewModel);
        }

        public ActionResult Image(int id)
        {
            var image = this.db.Images.GetById(id);
            if (image == null)
            {
                throw new HttpException(404, "Image not found");
            }
            return File(image.Content, "image/" + image.FileExtension);
        }

    }
}