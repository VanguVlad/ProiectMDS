using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.Models
{
    public class Writer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }

        public List<BookWriter> BookWriter { get; set; }
        public List<WriterCategory> WriterCategory { get; set; }

    }
}
