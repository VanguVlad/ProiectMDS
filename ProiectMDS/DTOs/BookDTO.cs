using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.DTOs
{
    public class BookDTO
    {
        public string Name { get; set; }
        public string Popularity { get; set; }
        public int PublicationYear { get; set; }

        public List<int> WriterId { get; set; }
        public List<int> LibraryId { get; set; }
        public List<int> PublisherId { get; set; }

    }
}
