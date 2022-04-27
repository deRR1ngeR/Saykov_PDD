using System;
using System.Collections.Generic;

namespace Kursach
{
    public partial class User
    {
        public int UserId { get; set; }
        public int LoginId { get; set; }
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? Patronim { get; set; }
        public int? Results { get; set; }
        public string? Exam { get; set; }

        public virtual ExamResult? ExamNavigation { get; set; }
        public virtual Login Login { get; set; } = null!;
        public virtual TicketResult? ResultsNavigation { get; set; }
    }
}
