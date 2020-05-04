using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;

namespace ProiectMDS.Repositories.PublisherRepository
{
    public interface IPublisherRepository
    {
        List<Publisher> GetAll();
        Publisher Get(int Id);
        Publisher Create(Publisher Publisher);
        Publisher Update(Publisher Publisher);
        Publisher Delete(Publisher Publisher);
    }
}
