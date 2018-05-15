using StudentWebMarket.Data.EF;
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
    public class StudentWebMarketData : IStudentWebMarketData
    {
        private readonly DbContext context;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public StudentWebMarketData()
            : this(new StudentWebMarketDbContext())
        {
        }
        public StudentWebMarketData(DbContext context)
        {
            this.context = context;
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                return this.GetRepository<Category>();
            }
        }

        public IRepository<Product> Products
        {
            get
            {
                return this.GetRepository<Product>();
            }
        }
        public IRepository<Condition> Conditions
        {
            get
            {
                return this.GetRepository<Condition>();
            }
        }
        public IRepository<Image> Images
        {
            get
            {
                return this.GetRepository<Image>();
            }
        }
        public IRepository<School> Schools
        {
            get
            {
                return this.GetRepository<School>();
            }
        }
        public IRepository<StudentProgram> StudentPrograms
        {
            get
            {
                return this.GetRepository<StudentProgram>();
            }
        }


        public DbContext Context
        {
            get
            {
                return this.context;
            }
        }



        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

    }
}
