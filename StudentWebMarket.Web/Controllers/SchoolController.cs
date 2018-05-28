using StudentWebMarket.Data.EF;
using StudentWebMarket.Data.Repositories;
using StudentWebMarket.Models.Models;
using System.Web.Mvc;

namespace StudentWebMarket.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SchoolController : BaseController
    {

        private SchoolRepository schoolRepository = null;
        private StudentWebMarketDbContext data = new StudentWebMarketDbContext();

        public SchoolController()
        {
            schoolRepository = new SchoolRepository();
        }

        public ActionResult Index()
        {
            var school = schoolRepository.FindAll();
            return View(school);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(School school)
        {
            if (ModelState.IsValid)
            {
                schoolRepository.Insert(school);
                schoolRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(school);
            }
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var school = schoolRepository.GetById(Id);
            return View(school);
        }

        [HttpPost]
        public ActionResult Edit(School school)
        {
            if (ModelState.IsValid)
            {
                schoolRepository.Update(school);
                schoolRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(school);
            }
        }

        public ActionResult Delete(int Id)
        {
            var school = schoolRepository.GetById(Id);
            return View(school);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            var school = schoolRepository.GetById(Id);
            schoolRepository.Delete(Id);
            schoolRepository.Save();
            return RedirectToAction("Index");
        }
    }
}