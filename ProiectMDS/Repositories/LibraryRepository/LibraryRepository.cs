using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;



namespace ProiectMDS.Repositories.LibraryRepository
{
    public class LibraryRepository : ILibraryRepository
    {
        public Context _context { get; set; }

        public LibraryRepository(Context context)
        {
            _context = context;

        }
        public Library Create(Library Library)
        {
            var result = _context.Add<Library>(Library);
            _context.SaveChanges();
            return result.Entity;
        }

        public Library Get(int Id)
        {
            return _context.Library.SingleOrDefault(x => x.Id == Id);
        }
        public List<Library> GetAll()
        {
            return _context.Library.ToList();
        }
        public Library Update(Library Library)
        {
            _context.Entry(Library).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Library;
        }
        public Library Delete(Library Library)
        {
            var result = _context.Remove(Library);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
