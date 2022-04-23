using System;
using System.Collections.Generic;

namespace Kursach.Models
{
    public partial class Exam
    {
        public Exam()
        {
            TicketExams = new HashSet<TicketExam>();
        }

        public int ExamId { get; set; }
        public string? ExamResult { get; set; }

        public virtual ExamResult? ExamResultNavigation { get; set; }
        public virtual ICollection<TicketExam> TicketExams { get; set; }
    }
}
