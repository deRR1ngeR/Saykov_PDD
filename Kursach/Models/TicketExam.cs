using System;
using System.Collections.Generic;

namespace Kursach
{
    public partial class TicketExam
    {
        public int Id { get; set; }
        public int? TicketId { get; set; }
        public int? ExamId { get; set; }

        public virtual Exam? Exam { get; set; }
        public virtual Ticket? Ticket { get; set; }
    }
}
