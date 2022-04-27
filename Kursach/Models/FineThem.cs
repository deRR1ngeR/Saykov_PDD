using System;
using System.Collections.Generic;

namespace Kursach
{
    public partial class FineThem
    {
        public FineThem()
        {
            Fines = new HashSet<Fine>();
        }

        public int FineId { get; set; }
        public string? FineText { get; set; }

        public virtual ICollection<Fine> Fines { get; set; }
    }
}
