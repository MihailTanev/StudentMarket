using StudentWebMarket.Data.EF;
using StudentWebMarket.Data.Repositories;
using StudentWebMarket.Models.Models;
using System.Web.Mvc;

namespace StudentWebMarket.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : BaseController
    {

        private CategoryRepository categoryRepository = null;
        private StudentWebMarketDbContext data = new StudentWebMarketDbContext();

        public CategoryController()
        {
            categoryRepository = new CategoryRepository();
        }

        // GET: Course
        public ActionResult Index()
        {
            var category = categoryRepository.FindAll();
            return View(category);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.Insert(category);
                categoryRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var category = categoryRepository.GetById(Id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.Update(category);
                categoryRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }

        public ActionResult Delete(int Id)
        {
            var school = categoryRepository.GetById(Id);
            return View(school);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            var category = categoryRepository.GetById(Id);
            categoryRepository.Delete(Id);
            categoryRepository.Save();
            return RedirectToAction("Index");
        }
    }
}