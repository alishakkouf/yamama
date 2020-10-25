using System;
using System.Collections.Generic;

namespace Yamama
{
    public partial class User
    {
        public User()
        {
            Visit = new HashSet<Visit>();
        }

        public int Iduser { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EMail { get; set; }
        public int? Phone { get; set; }
        public int? RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Visit> Visit { get; set; }
    }
}
