using Microsoft.EntityFrameworkCore;
using Kursach.Model;

namespace Kursach.Model
{
    internal class ApplicationContext : DbContext
    {

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = .\SQLEXPR; Database = PDD_Kursach; Trusted_Connection = True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}