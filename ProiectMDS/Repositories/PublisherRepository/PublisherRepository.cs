using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;



namespace ProiectMDS.Repositories.PublisherRepository
{
    public class PublisherRepository : IPublisherRepository
    {
        public Context _context { get; set; }

        public PublisherRepository(Context context)
        {
            _context = context;

        }
        public Publisher Create(Publisher Publisher)
        {
            var result = _context.Add<Publisher>(Publisher);
            _context.SaveChanges();
            return result.Entity;
        }

        public Publisher Get(int Id)
        {
            return _context.Publisher.SingleOrDefault(x => x.Id == Id);
        }
        public List<Publisher> GetAll()
        {
            return _context.Publisher.ToList();
        }
        public Publisher Update(Publisher Publisher)
        {
            _context.Entry(Publisher).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Publisher;
        }
        public Publisher Delete(Publisher Publisher)
        {
            var result = _context.Remove(Publisher);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
