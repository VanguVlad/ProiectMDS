using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.Models
{
    public class BookWriter
    {
        public int Id { get; set; }
        public int WriterId { get; set; }
        public int BookId { get; set; }


        public virtual Writer Writer { get; set; }
        public virtual Book Book { get; set; }

    }
}
