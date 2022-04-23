using System;
using System.Collections.Generic;

namespace Kursach.Models
{
    public partial class Fine
    {
        public int FineId { get; set; }
        public int FineThemId { get; set; }
        public string? FineText { get; set; }
        public int? FineCost { get; set; }

        public virtual FineThem FineThem { get; set; } = null!;
    }
}
