using System;
using System.Collections.Generic;

namespace Kursach
{
    public partial class TicketResult
    {
        public TicketResult()
        {
            Users = new HashSet<User>();
        }

        public int TicketResultId { get; set; }
        public string? TicketResult1 { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
