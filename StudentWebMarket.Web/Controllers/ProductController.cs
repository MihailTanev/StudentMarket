using Microsoft.AspNet.Identity;
using StudentWebMarket.Data.EF;
using StudentWebMarket.Models.Models;
using StudentWebMarket.Web.ViewModels;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace StudentWebMarket.Web.Controllers
{
    public class ProductController : BaseController
    {
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            var model = new CreateProductViewModel();
            DropDownList();
            DropDownListCondition();
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(CreateProductViewModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var user = User.Identity.GetUserId();
                    byte[] content = null;
                    string fileExtension = null;
                    //image size up to 10MB
                    if (model.UploadPhoto != null && model.UploadPhoto.ContentLength <= (1024 * 1024 * 10))
                    {
                        using (var mem = new MemoryStream(model.UploadPhoto.ContentLength))
                        {
                            model.UploadPhoto.InputStream.CopyTo(mem);
                            content = mem.GetBuffer();
                            fileExtension = model.UploadPhoto.FileName.Split(new[] { '.' }).Last();
                        }
                        
                    }

                    var book = new Product
                    {
                        OriginalPrice = model.OriginaPrice ?? 0,
                        SalePrice = model.SalePrice ?? 0,
                        CategoryId = model.CategoryId,
                        Year = model.Year ?? 0,
                        ConditionId = model.ConditionId,
                        CreatedOn = DateTime.Now,
                        Name = model.Name,
                        SellerId = user,
                        Description = model.Description,
                        Image = new Image { Content = content, FileExtension = fileExtension }
                    };

                    this.db.Products.Add(book);
                    this.db.SaveChanges();
                    TempData["Success"] = "Your Ad has been successfully submitted!";

                }
                //TempData["Success"] = "Your Item Has Been Added Successfully!";
                return RedirectToAction("Create", "Product");
            }
            catch
            {
                TempData["Failed"] = "File upload failed! Select file and course";
                return RedirectToAction("Create", "Product");
            }
        }

        private void DropDownList(object selectedCourses = null)
        {
            StudentWebMarketDbContext db = new StudentWebMarketDbContext();
            var courseQuery = from d in db.Categories
                              orderby d.Name
                              select d;
            ViewBag.CategoryId = new SelectList(courseQuery, "CategoryId", "Name", selectedCourses);
        }

        private void DropDownListCondition(object selectedConditions = null)
        {
            StudentWebMarketDbContext db = new StudentWebMarketDbContext();
            var conditionQuery = from d in db.Conditions
                                 orderby d.Name
                                 select d;
            ViewBag.ConditionId = new SelectList(conditionQuery, "ConditionId", "Name", selectedConditions);
        }


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