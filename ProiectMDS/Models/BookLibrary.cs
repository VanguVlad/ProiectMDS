using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.Models
{
    public class BookLibrary
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int LibraryId { get; set; }


        public virtual Book Book { get; set; }
        public virtual Library Library { get; set; }

    }
}
