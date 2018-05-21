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
    public class StudentProgramRepository : IStudentProgramRepository
    {
        private StudentWebMarketDbContext db;
        private DbSet<StudentProgram> dbSet;

        public StudentProgramRepository()
        {
            db = new StudentWebMarketDbContext();
            dbSet = db.Set<StudentProgram>();

        }
        public List<StudentProgram> FindAll()
        {
            return db.StudentPrograms.ToList();
        }
        public StudentProgram GetById(object Id)
        {
            return dbSet.Find(Id);
        }

        public void Insert(StudentProgram obj)
        {
            dbSet.Add(obj);
        }

        public void Update(StudentProgram obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object Id)
        {
            StudentProgram getObjById = dbSet.Find(Id);
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
