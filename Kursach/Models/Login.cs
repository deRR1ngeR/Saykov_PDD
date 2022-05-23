using System;
using System.Collections.Generic;

namespace Kursach.Models
{
    public partial class Login
    {
        public Login()
        {
            TicketResults = new HashSet<TicketResult>();
        }

        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Adress { get; set; }
        public string? Phone { get; set; }
        public bool IsAdmin { get; set; }
        public string? UserName { get; set; }
        public string? UserSurname { get; set; }
        public DateTime? RegDate { get; set; }
        public DateTime? LastEnter { get; set; }
        public virtual ICollection<TicketResult> TicketResults { get; set; }
    }
}
