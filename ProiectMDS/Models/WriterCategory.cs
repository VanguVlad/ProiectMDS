using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.Models
{
    public class WriterCategory
    {
        public int Id { get; set; }
        public int WriterId { get; set; }
        public int CategoryId { get; set; }


        public virtual Writer Writer { get; set; }
        public virtual Category Category { get; set; }

    }
}
