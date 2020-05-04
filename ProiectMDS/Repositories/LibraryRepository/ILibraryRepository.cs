using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;

namespace ProiectMDS.Repositories.LibraryRepository
{
    public interface ILibraryRepository
    {
        List<Library> GetAll();
        Library Get(int Id);
        Library Create(Library Library);
        Library Update(Library Library);
        Library Delete(Library Library);
    }
}
