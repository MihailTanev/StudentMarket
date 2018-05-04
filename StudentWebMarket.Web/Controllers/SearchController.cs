using System.Linq;
using System.Web.Mvc;

namespace StudentWebMarket.Web.Controllers
{
    public class SearchProductController : BaseController
    {
        public ActionResult Search(string searchstring)
        {
            // Define the query expression
            var products = from s in this.db.Products.All()
                           orderby s.CreatedOn descending
                           select s;

            // Execute the query
            if (!string.IsNullOrEmpty(searchstring))
            {
                products = products
                    .Where(s => s.Name
                    .Contains(searchstring) || s
                    .Category.Name.Contains(searchstring))
                    .OrderByDescending(s => s.CreatedOn);
            }
            return PartialView("_ProductPartial", products.ToList()
                .OrderByDescending(x => x.CreatedOn));
        }
    }
}