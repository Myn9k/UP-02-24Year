using System;
using System.Data.Entity;
using System.Linq;

namespace _1_Libary
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Register> Registers { get; set; }
        public DbSet<Root> Roots { get; set; }
        public ApplicationContext(): base("name=DefaultConnection")
        {
        }
    }
}