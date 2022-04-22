using Microsoft.EntityFrameworkCore;
using Kursach.Models;
using System.Data.Entity;


namespace Kursach.Models
{
    internal class ApplicationContext : System.Data.Entity.DbContext
    {

        public ApplicationContext(): base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<PDD_Fine> PDD_Fine { get; set; }
        public System.Data.Entity.DbSet<User> User { get; set; }
        public System.Data.Entity.DbSet<Admin> Admin { get; set; }
        public System.Data.Entity.DbSet<PDD_Info> PDD_Info { get; set; }
        public System.Data.Entity.DbSet<Ticket> Ticket { get; set; }
        public System.Data.Entity.DbSet<Ticket_Exam> ticket_Exams { get; set; }
        public System.Data.Entity.DbSet<Login> Login { get; set; }
        public System.Data.Entity.DbSet<Question> questions { get; set; }
        public System.Data.Entity.DbSet<Exam> exam { get; set; }
      


    }
}