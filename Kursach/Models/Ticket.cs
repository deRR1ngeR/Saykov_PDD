﻿using System;
using System.Collections.Generic;

namespace Kursach.Models
{
    public partial class Ticket
    {
        public Ticket()
        {
            Questions = new HashSet<Question>();
            TicketExams = new HashSet<TicketExam>();
        }

        public int TicketId { get; set; }
        public string TicketResult { get; set; } = null!;

        public virtual TicketResult TicketResultNavigation { get; set; } = null!;
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<TicketExam> TicketExams { get; set; }
    }
}