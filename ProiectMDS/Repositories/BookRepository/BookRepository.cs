using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;



namespace ProiectMDS.Repositories.BookRepository
{
    public class BookRepository:IBookRepository
    {
        public Context _context { get; set; }

        public BookRepository(Context context)
        {
            _context = context;

        }
        public Book Create(Book Book)
        {
            var result = _context.Add<Book>(Book);
            _context.SaveChanges();
            return result.Entity;
        }

        public Book Get(int Id)
        {
            return _context.Books.SingleOrDefault(x => x.Id == Id);
        }
        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }
        public Book Update(Book Book)
        {
            _context.Entry(Book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Book;
        }
        public Book Delete(Book Book)
        {
            var result = _context.Remove(Book);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
