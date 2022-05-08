using System;
using System.Collections.Generic;

namespace Kursach
{
    public partial class ExamResult
    {
        public ExamResult()
        {
            Exams = new HashSet<Exam>();
        }

        public string ExamResults { get; set; } = null!;

        public virtual ICollection<Exam> Exams { get; set; }
    }
}
