using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Models
{
    internal class Exam
    {
        public int ExamId { get; set; }
        public string? Exam_result { get; set; }
        public List<User>? User { get; set; }
    }
}
