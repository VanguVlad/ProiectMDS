using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.DTOs
{
    public class BookDetailsDTO
    {
        public string Name { get; set; }
        public string Popularity { get; set; }
        public int PublicationYear { get; set; }

        public List<string> WriterName { get; set; }
        public List<string> LibraryName { get; set; }
        public List<string> PublisherName { get; set; }
    }
}
