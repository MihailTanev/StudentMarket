using Microsoft.AspNet.Identity.EntityFramework;
using StudentWebMarket.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWebMarket.Data.EF
{
    public class StudentWebMarketDbContext : IdentityDbContext<User>
    {
        public StudentWebMarketDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Product> Products { get; set; }
        public virtual IDbSet<Category> Categories { get; set; }
        public virtual IDbSet<Condition> Conditions { get; set; }
        public virtual IDbSet<Image> Images { get; set; }


        public static StudentWebMarketDbContext Create()
        {
            return new StudentWebMarketDbContext();
        }
    }
}
