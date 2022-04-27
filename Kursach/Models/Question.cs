using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Kursach
{
    public partial class Question
    {
        public int QuestionId { get; set; }
        public string? QuestionText { get; set; }
        public string? RightAnswer { get; set; }
        public string? Answer1 { get; set; }
        public string? Answer2 { get; set; }
        public string? Answer3 { get; set; }
        public string? Answer4 { get; set; }
        public int TicketId { get; set; }
        public string? QuestionImg { get; set; }

        public virtual Ticket Ticket { get; set; } = null!;

        public static explicit operator ObservableCollection<object>(Question? v)
        {
            throw new NotImplementedException();
        }
    }
}
