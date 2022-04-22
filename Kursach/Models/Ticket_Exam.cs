using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Models
{
    internal class Ticket_Exam
    {
        public int Ticket_ExamId { get; set; }
        public int Ticket_Id { get; set; }
        public int Exam_id { get; set; }
        public Ticket? Ticket { get; set; }
        public Exam? Exam { get; set; }
    }
}
