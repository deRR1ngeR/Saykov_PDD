using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Models
{
    internal class Login
    {
        [Key]
        public int Login_id { get; set; }
        public string? Login_name { get; set; }
        public string? Password { get; set; }
    }
}
