using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;



namespace ProiectMDS.Repositories.WriterCategoryRepository
{
    public class WriterCategoryRepository : IWriterCategoryRepository
    {
        public Context _context { get; set; }

        public WriterCategoryRepository(Context context)
        {
            _context = context;

        }
        public WriterCategory Create(WriterCategory WriterCategory)
        {
            var result = _context.Add<WriterCategory>(WriterCategory);
            _context.SaveChanges();
            return result.Entity;
        }

        public WriterCategory Get(int Id)
        {
            return _context.WriterCategory.SingleOrDefault(x => x.Id == Id);
        }
        public List<WriterCategory> GetAll()
        {
            return _context.WriterCategory.ToList();
        }
        public WriterCategory Update(WriterCategory WriterCategory)
        {
            _context.Entry(WriterCategory).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return WriterCategory;
        }
        public WriterCategory Delete(WriterCategory WriterCategory)
        {
            var result = _context.Remove(WriterCategory);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
