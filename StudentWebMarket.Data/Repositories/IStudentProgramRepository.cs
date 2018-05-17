using StudentWebMarket.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWebMarket.Data.Repositories
{
    public interface IStudentProgramRepository
    {
        List<StudentProgram> FindAll();
        StudentProgram GetById(object Id);
        void Insert(StudentProgram Id);
        void Update(StudentProgram Id);
        void Delete(object Id);
        void Save();
    }
}
