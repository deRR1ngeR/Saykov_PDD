using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Models
{
    internal class Admin
    {
        [Key]
        public int Admin_id { get; set; }
        public int Login_id { get; set; }
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? Patronim { get; set; }
        public DateTime Birthday { get; set; }
        public string? Phone_number { get; set; }
        public DateTime Date_of_entry { get; set; }
        public Login? Login { get; set; }
    }
}
