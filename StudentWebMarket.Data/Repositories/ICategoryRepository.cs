using StudentWebMarket.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWebMarket.Data.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> FindAll();
        Category GetById(object Id);
        void Insert(Category Id);
        void Update(Category Id);
        void Delete(object Id);
        void Save();
    }
}
