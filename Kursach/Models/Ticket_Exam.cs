using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Models
{
    internal class Ticket_Exam
    {
        public Guid Id { get; set; }
        public Ticket Ticket_Id { get; set; }
        public Exam Exam_id { get; set; }
    }
}
