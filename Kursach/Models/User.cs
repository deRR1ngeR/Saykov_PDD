using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Models
{
    internal class User
    {
        public string User_id { get; set; }
        public  Guid Login_id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronim { get; set; }
        public List<Exam_results> exam_Results { get; set; }
        public List<Ticket_results> ticket_Results { get; set; }
    }
}
