using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Models
{
    internal class Question
    {
        public int QuestionId { get; set; }
        public string? Question_text{ get; set; }
        public string? Right_answer { get; set; }
        public string? Answer_1 { get; set; }
        public string? Answer_2 { get; set; }
        public string? Answer_3 { get; set; }
        public int Ticket_Id { get; set; }
        public Ticket? Ticket { get; set; }
    }
}

