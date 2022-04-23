using Kursach.Models;
using System;
using System.Collections.Generic;

namespace Kursach
{
    public partial class Admin
    {
        public int AdminId { get; set; }
        public int LoginId { get; set; }
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? Patronim { get; set; }
        public DateTime? Birthday { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? DateOfEntry { get; set; }

        public virtual Login Login { get; set; } = null!;
    }
}
