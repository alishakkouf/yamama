using System;
using System.Collections.Generic;

namespace Yamama.Models
{
    public partial class Role
    {
        public Role()
        {
            User = new HashSet<User>();
        }

        public int Idrole { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
