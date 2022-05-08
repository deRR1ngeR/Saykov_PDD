using System;
using System.Collections.Generic;

namespace Kursach
{
    public partial class TicketResult
    {
        public TicketResult()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int TicketResultId { get; set; }
        public string? TicketResult1 { get; set; }
        public int UserId { get; set; }

        public virtual Login User { get; set; } = null!;
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
