using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;

namespace ProiectMDS.Repositories.BookPublisherRepository
{
    public interface IBookPublisherRepository
    {
        List<BookPublisher> GetAll();
        BookPublisher Get(int Id);
        BookPublisher Create(BookPublisher BookPublisher);
        BookPublisher Update(BookPublisher BookPublisher);
        BookPublisher Delete(BookPublisher BookPublisher);
    }
}
