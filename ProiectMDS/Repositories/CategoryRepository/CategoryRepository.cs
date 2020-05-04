using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;



namespace ProiectMDS.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        public Context _context { get; set; }

        public CategoryRepository(Context context)
        {
            _context = context;

        }
        public Category Create(Category Category)
        {
            var result = _context.Add<Category>(Category);
            _context.SaveChanges();
            return result.Entity;
        }

        public Category Get(int Id)
        {
            return _context.Category.SingleOrDefault(x => x.Id == Id);
        }
        public List<Category> GetAll()
        {
            return _context.Category.ToList();
        }
        public Category Update(Category Category)
        {
            _context.Entry(Category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Category;
        }
        public Category Delete(Category Category)
        {
            var result = _context.Remove(Category);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
