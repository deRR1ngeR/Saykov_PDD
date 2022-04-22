using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Models
{
    internal class PDD_Fine
    {
        [Key]
        public int Fine_id { get; set; }
        public string? Fine_text { get; set; }

    }
}
