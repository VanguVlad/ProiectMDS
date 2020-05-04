using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;



namespace ProiectMDS.Repositories.BookLibraryRepository
{
    public class BookLibraryRepository : IBookLibraryRepository
    {
        public Context _context { get; set; }

        public BookLibraryRepository(Context context)
        {
            _context = context;

        }
        public BookLibrary Create(BookLibrary BookLibrary)
        {
            var result = _context.Add<BookLibrary>(BookLibrary);
            _context.SaveChanges();
            return result.Entity;
        }

        public BookLibrary Get(int Id)
        {
            return _context.BookLibrary.SingleOrDefault(x => x.Id == Id);
        }
        public List<BookLibrary> GetAll()
        {
            return _context.BookLibrary.ToList();
        }
        public BookLibrary Update(BookLibrary BookLibrary)
        {
            _context.Entry(BookLibrary).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return BookLibrary;
        }
        public BookLibrary Delete(BookLibrary BookLibrary)
        {
            var result = _context.Remove(BookLibrary);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
