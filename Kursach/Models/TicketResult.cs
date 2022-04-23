using System;
using System.Collections.Generic;

namespace Kursach.Models
{
    public partial class TicketResult
    {
        public TicketResult()
        {
            Tickets = new HashSet<Ticket>();
            Users = new HashSet<User>();
        }

        public string TicketResult1 { get; set; } = null!;

        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
