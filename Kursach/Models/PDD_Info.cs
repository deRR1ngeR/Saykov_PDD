using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Models
{
    internal class PDD_Info
    {
        [Key]
        public int InfoId { get; set; }
        public string? PDD_Text { get; set; }
        public string? PDD_img { get; set; }
        
    }
}
