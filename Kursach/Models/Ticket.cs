using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Models
{
    internal class Ticket
    {
        public int TicketId  { get; set; }
        public string? Ticket_result  { get; set; }
        public List<User>? User { get; set; }
    }
}
