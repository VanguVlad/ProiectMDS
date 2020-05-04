using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;



namespace ProiectMDS.Repositories.BookPublisherRepository
{
    public class BookPublisherRepository : IBookPublisherRepository
    {
        public Context _context { get; set; }

        public BookPublisherRepository(Context context)
        {
            _context = context;

        }
        public BookPublisher Create(BookPublisher BookPublisher)
        {
            var result = _context.Add<BookPublisher>(BookPublisher);
            _context.SaveChanges();
            return result.Entity;
        }

        public BookPublisher Get(int Id)
        {
            return _context.BookPublisher.SingleOrDefault(x => x.Id == Id);
        }
        public List<BookPublisher> GetAll()
        {
            return _context.BookPublisher.ToList();
        }
        public BookPublisher Update(BookPublisher BookPublisher)
        {
            _context.Entry(BookPublisher).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return BookPublisher;
        }
        public BookPublisher Delete(BookPublisher BookPublisher)
        {
            var result = _context.Remove(BookPublisher);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
