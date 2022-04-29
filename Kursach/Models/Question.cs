using System;
using System.Collections.Generic;

namespace Kursach
{
    public partial class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
        }

        public int QuestionId { get; set; }
        public string? QuestionText { get; set; }
        public int TicketId { get; set; }
        public string? QuestionImg { get; set; }

        public virtual Ticket Ticket { get; set; } = null!;
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
