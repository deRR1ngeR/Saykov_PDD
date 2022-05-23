using System;
using System.Collections.Generic;

namespace Kursach.Models
{
    public partial class Ticket
    {
        public Ticket()
        {
            Questions = new HashSet<Question>();
        }

        public int TicketId { get; set; }
        public string? TicketResult { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
