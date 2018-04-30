using StudentWebMarket.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentWebMarket.Web.Controllers
{
    public class BaseController : Controller
    {
        protected IStudentWebMarketData db;

        public BaseController(IStudentWebMarketData _db)
        {
            this.db = _db;
        }
        public BaseController()
                : this(new StudentWebMarketData())
        {
        }
    }
}