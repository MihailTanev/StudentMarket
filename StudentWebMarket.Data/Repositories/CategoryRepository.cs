using StudentWebMarket.Data.EF;
using StudentWebMarket.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWebMarket.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private StudentWebMarketDbContext db;
        private DbSet<Category> dbSet;

        public CategoryRepository()
        {
            db = new StudentWebMarketDbContext();
            dbSet = db.Set<Category>();

        }
        public List<Category> FindAll()
        {
            return db.Categories.ToList();
        }
        public Category GetById(object Id)
        {
            return dbSet.Find(Id);
        }

        public void Insert(Category obj)
        {
            dbSet.Add(obj);
        }

        public void Update(Category obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object Id)
        {
            Category getObjById = dbSet.Find(Id);
            dbSet.Remove(getObjById);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }
    }
}
