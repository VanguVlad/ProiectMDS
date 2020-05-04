using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;

namespace ProiectMDS.Repositories.BookLibraryRepository
{
    public interface IBookLibraryRepository
    {
        List<BookLibrary> GetAll();
        BookLibrary Get(int Id);
        BookLibrary Create(BookLibrary BookLibrary);
        BookLibrary Update(BookLibrary BookLibrary);
        BookLibrary Delete(BookLibrary BookLibrary);
    }
}
