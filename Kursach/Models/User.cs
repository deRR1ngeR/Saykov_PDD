﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Models
{
    internal class User
    {
        public int UserId { get; set; }
        public  int Login_id { get; set; }
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? Patronim { get; set; }
        public Login? Login { get; set; }
        public List<Ticket>? Ticket_Results { get; set; }
        public List<Exam>? Exam_Resilts { get; set;}
    }
}
