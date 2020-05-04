using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;

namespace ProiectMDS.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category Get(int Id);
        Category Create(Category Category);
        Category Update(Category Category);
        Category Delete(Category Category);
    }
}
