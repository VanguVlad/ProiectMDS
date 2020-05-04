using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;

namespace ProiectMDS.Repositories.WriterRepository
{
    public interface IWriterRepository
    {
        List<Writer> GetAll();
        Writer Get(int Id);
        Writer Create(Writer Writer);
        Writer Update(Writer Writer);
        Writer Delete(Writer Writer);
    }
}
