using StudentWebMarket.Data.EF;
using StudentWebMarket.Data.Repositories;
using StudentWebMarket.Models.Models;
using System.Web.Mvc;

namespace StudentWebMarket.Web.Controllers
{
    public class StudentProgramController : BaseController
    {
        private StudentProgramRepository studprogRepository = null;
        private StudentWebMarketDbContext data = new StudentWebMarketDbContext();

        public StudentProgramController()
        {
            studprogRepository = new StudentProgramRepository();
        }

        public ActionResult Index()
        {
            var school = studprogRepository.FindAll();
            return View(school);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(StudentProgram program)
        {
            if (ModelState.IsValid)
            {
                studprogRepository.Insert(program);
                studprogRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(program);
            }
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var program = studprogRepository.GetById(Id);
            return View(program);
        }

        [HttpPost]
        public ActionResult Edit(StudentProgram program)
        {
            if (ModelState.IsValid)
            {
                studprogRepository.Update(program);
                studprogRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(program);
            }
        }

        public ActionResult Delete(int Id)
        {
            var program = studprogRepository.GetById(Id);
            return View(program);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            var program = studprogRepository.GetById(Id);
            studprogRepository.Delete(Id);
            studprogRepository.Save();
            return RedirectToAction("Index");
        }
    }
}