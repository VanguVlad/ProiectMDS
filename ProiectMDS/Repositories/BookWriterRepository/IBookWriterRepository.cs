using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;

namespace ProiectMDS.Repositories.BookWriterRepository
{
    public interface IBookWriterRepository
    {
        List<BookWriter> GetAll();
        BookWriter Get(int Id);
        BookWriter Create(BookWriter BookWriter);
        BookWriter Update(BookWriter BookWriter);
        BookWriter Delete(BookWriter BookWriter);
    }
}
