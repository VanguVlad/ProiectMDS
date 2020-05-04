using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;

namespace ProiectMDS.Repositories.WriterCategoryRepository
{
    public interface IWriterCategoryRepository
    {
        List<WriterCategory> GetAll();
        WriterCategory Get(int Id);
        WriterCategory Create(WriterCategory WriterCategory);
        WriterCategory Update(WriterCategory WriterCategory);
        WriterCategory Delete(WriterCategory WriterCategory);
    }
}
