using System;
using System.Collections.Generic;

namespace Kursach.Models
{
    public partial class Question
    {
        public int QuestionId { get; set; }
        public string? QuestionText { get; set; }
        public string? RightAnswer { get; set; }
        public string? Answer1 { get; set; }
        public string? Answer2 { get; set; }
        public string? Answer3 { get; set; }
        public int TicketId { get; set; }
        public string? QuestionImg { get; set; }

        public virtual Ticket Ticket { get; set; } = null!;
    }
}
