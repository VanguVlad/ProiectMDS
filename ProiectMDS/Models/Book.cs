using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Popularity { get; set; }
        public int PublicationYear { get; set; }

        public List<BookWriter> BookWriter { get; set; }
        public List<BookLibrary> BookLibrary { get; set; }
        public List<BookPublisher> BookPublisher { get; set; }

    }
}
