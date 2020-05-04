using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;



namespace ProiectMDS.Repositories.BookWriterRepository
{
    public class BookWriterRepository : IBookWriterRepository
    {
        public Context _context { get; set; }

        public BookWriterRepository(Context context)
        {
            _context = context;

        }
        public BookWriter Create(BookWriter BookWriter)
        {
            var result = _context.Add<BookWriter>(BookWriter);
            _context.SaveChanges();
            return result.Entity;
        }

        public BookWriter Get(int Id)
        {
            return _context.BookWriter.SingleOrDefault(x => x.Id == Id);
        }
        public List<BookWriter> GetAll()
        {
            return _context.BookWriter.ToList();
        }
        public BookWriter Update(BookWriter BookWriter)
        {
            _context.Entry(BookWriter).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return BookWriter;
        }
        public BookWriter Delete(BookWriter BookWriter)
        {
            var result = _context.Remove(BookWriter);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
