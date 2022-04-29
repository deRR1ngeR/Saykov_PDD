using System;
using System.Collections.Generic;

namespace Kursach
{
    public partial class Answer
    {
        public int AnswersId { get; set; }
        public bool RightAnswer { get; set; }
        public string? Answer1 { get; set; }
        public int? QuestionId { get; set; }

        public virtual Question? Question { get; set; }
    }
}
