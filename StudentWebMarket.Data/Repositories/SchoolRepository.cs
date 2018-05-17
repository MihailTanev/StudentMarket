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
    public class SchoolRepository : ISchoolRepository
    {
        private StudentWebMarketDbContext db;
        private DbSet<School> dbSet;

        public SchoolRepository()
        {
            db = new StudentWebMarketDbContext();
            dbSet = db.Set<School>();

        }
        public List<School> FindAll()
        {
            return db.Schools.ToList();
        }
        public School GetById(object Id)
        {
            return dbSet.Find(Id);
        }

        public void Insert(School obj)
        {
            dbSet.Add(obj);
        }

        public void Update(School obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object Id)
        {
            School getObjById = dbSet.Find(Id);
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
