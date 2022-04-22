using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Models
{
    internal class Admin
    {
        public int AdminId { get; set; }
        public int Login_Id { get; set; }
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? Patronim { get; set; }
        public DateTime Birthday { get; set; }
        public string? Phone_number { get; set; }
        public DateTime Date_of_entry { get; set; }
        public Login? Login { get; set; }
    }
}
