using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;



namespace ProiectMDS.Repositories.WriterRepository
{
    public class WriterRepository : IWriterRepository
    {
        public Context _context { get; set; }

        public WriterRepository(Context context)
        {
            _context = context;

        }
        public Writer Create(Writer Writer)
        {
            var result = _context.Add<Writer>(Writer);
            _context.SaveChanges();
            return result.Entity;
        }

        public Writer Get(int Id)
        {
            return _context.Writer.SingleOrDefault(x => x.Id == Id);
        }
        public List<Writer> GetAll()
        {
            return _context.Writer.ToList();
        }
        public Writer Update(Writer Writer)
        {
            _context.Entry(Writer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Writer;
        }
        public Writer Delete(Writer Writer)
        {
            var result = _context.Remove(Writer);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
