using StudentWebMarket.Data.Repositories;
using StudentWebMarket.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWebMarket.Data.UnitOfWork
{
    public interface IStudentWebMarketData
    {

        IRepository<Category> Categories { get; }
        IRepository<Product> Products { get; }
        DbContext Context { get; }
        IRepository<Image> Images { get; }
        IRepository<User> Users { get; }
        IRepository<Condition> Conditions { get; }
        IRepository<School> Schools { get; }
        IRepository<StudentProgram> StudentPrograms { get; }

        void Dispose();
        int SaveChanges();
    }
}
