using System;
using System.Collections.Generic;

namespace Kursach.Models
{
    public partial class TicketResult
    {
        public int TicketResultId { get; set; }
        public string? TicketResult1 { get; set; }
        public int UserId { get; set; }
        public DateTime? ResDate { get; set; }
        public int? TicketId { get; set; }
        public bool isPassed { get; set; }
        public virtual Login User { get; set; } = null!;
    }
}
