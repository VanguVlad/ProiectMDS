using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProiectMDS.Models;
namespace ProiectMDS.Contexts
{
    public class Context : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookLibrary> BookLibrary { get; set; }
        public DbSet<BookPublisher> BookPublisher { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Library> Library { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Writer> Writer { get; set; }
        public DbSet<BookWriter> BookWriter { get; set; }
        public DbSet<WriterCategory> WriterCategory { get; set; }


        public static bool isMigration = true;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (isMigration)
                optionsBuilder.UseSqlServer(@"Server=.;Database=DBProiectMDS;Trusted_Connection=True;");
        }
        public Context()
        {

        }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
    }
}
