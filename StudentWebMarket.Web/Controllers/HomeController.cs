using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using StudentWebMarket.Data.EF;
using StudentWebMarket.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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

        public ActionResult ProductsByCategory(int id)
        {
            var model = this.db.Categories.GetById(id).Products.ToList();
            return PartialView("_ProductPartial", model.ToList()
                .OrderByDescending(x => x.CreatedOn));
        }

        public FileContentResult UserPhotos()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity.GetUserId();

                if (user == null)
                {
                    string fileName = HttpContext.Server.MapPath("C:/Users/Navn/Source/Repos/StudentWebMarket/StudentWebMarket.Data/Migrations/Images/java.jpg");

                    byte[] imageData = null;
                    FileInfo fileInfo = new FileInfo(fileName);
                    long imageFileLength = fileInfo.Length;
                    FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    imageData = br.ReadBytes((int)imageFileLength);

                    return File(imageData, "image/jpg");

                }
                // to get the user details to load user Image
                var dbUsers = HttpContext.GetOwinContext().Get<StudentWebMarketDbContext>();
                var userImage = dbUsers.Users.Where(x => x.Id == user).FirstOrDefault();

                return new FileContentResult(userImage.UserPhoto, "image/jpg");
            }
            else
            {
                string fileName = HttpContext.Server.MapPath("C:/Users/Navn/Source/Repos/StudentWebMarket/StudentWebMarket.Data/Migrations/Images/java.jpg");

                byte[] imageData = null;
                FileInfo fileInfo = new FileInfo(fileName);
                long imageFileLength = fileInfo.Length;
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                imageData = br.ReadBytes((int)imageFileLength);
                return File(imageData, "image/jpg");
            }
        }
    }
}