using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.Models
{
    public class BookPublisher
    {
        public int Id { get; set; }
        public int PublisherId { get; set; }
        public int BookId { get; set; }


        public virtual Publisher Publisher { get; set; }
        public virtual Book Book { get; set; }

    }
}
