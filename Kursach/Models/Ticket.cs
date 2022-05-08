using System;
using System.Collections.Generic;

namespace Kursach
{
    public partial class Ticket
    {
        public Ticket()
        {
            Questions = new HashSet<Question>();
            TicketExams = new HashSet<TicketExam>();
        }

        public int TicketId { get; set; }
        public string? TicketResult { get; set; }
        public int? ResultId { get; set; }

        public virtual TicketResult? Result { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<TicketExam> TicketExams { get; set; }
    }
}
