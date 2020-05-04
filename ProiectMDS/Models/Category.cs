using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discount { get; set; }

        public List<WriterCategory> WriterCategory { get; set; }

    }
}
