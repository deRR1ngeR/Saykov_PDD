using System;
using System.Collections.Generic;

namespace Kursach
{
    public partial class Fine
    {
        public int FineId { get; set; }
        public int FineThemId { get; set; }
        public string? FineText { get; set; }
        public string? FineCost { get; set; }
        public string? FineTime { get; set; }
        public string? FineImg { get; set; }

        public virtual FineThem FineThem { get; set; } = null!;
    }
}
