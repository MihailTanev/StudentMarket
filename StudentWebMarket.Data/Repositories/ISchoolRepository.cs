using StudentWebMarket.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWebMarket.Data.Repositories
{
    public interface ISchoolRepository
    {
        List<School> FindAll();
        School GetById(object Id);
        void Insert(School Id);
        void Update(School Id);
        void Delete(object Id);
        void Save();
    }
}
