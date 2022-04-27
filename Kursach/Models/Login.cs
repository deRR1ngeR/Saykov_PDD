using System;
using System.Collections.Generic;

namespace Kursach
{
    public partial class Login
    {
        public Login()
        {
            Admins = new HashSet<Admin>();
            Users = new HashSet<User>();
        }

        public int LoginId { get; set; }
        public string? LoginName { get; set; }
        public string? Passwords { get; set; }

        public virtual ICollection<Admin> Admins { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
