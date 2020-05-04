using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;

namespace ProiectMDS.Repositories.BookRepository
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        Book Get(int Id);
        Book Create(Book Book);
        Book Update(Book Book);
        Book Delete(Book Book);
    }
}
