using StudentWebMarket.Data.EF;
using System.Linq;
using System.Web.Mvc;

namespace StudentWebMarket.Web.Controllers
{
    public class SearchProductController : BaseController
    {
        StudentWebMarketDbContext data = new StudentWebMarketDbContext();

        public ActionResult Search(string searchstring)
        {

            var products = from s in data.Products
                           orderby s.CreatedOn descending
                           select s;

            if (!string.IsNullOrEmpty(searchstring))
            {
                products = products
                    .Where(s => s.Name
                    .Contains(searchstring) || s
                    .Category.Name.Contains(searchstring))
                    .OrderByDescending(x => x.CreatedOn);
            }
            return PartialView("_ProductPartial", products.ToList()
                .OrderByDescending(x => x.CreatedOn));
        }
    }
}