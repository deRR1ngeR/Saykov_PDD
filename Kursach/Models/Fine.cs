using System;
using System.Collections.Generic;

namespace Kursach.Models
{
    public partial class Fine
    {
        public int FineId { get; set; }
        public int FineThemId { get; set; }
        public string? Fine_Text { get; set; }
        public string? FineCost { get; set; }

        public virtual FineThem FineThem { get; set; } = null!;
    }
}
