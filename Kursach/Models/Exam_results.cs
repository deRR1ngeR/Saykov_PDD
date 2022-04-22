using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Models
{
    internal class Exam_results
    {
        [Key]
        public  List<Exam>? Exam_Results { get; set; }
    }
}
