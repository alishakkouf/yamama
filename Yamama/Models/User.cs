using System;
using System.Collections.Generic;

namespace Yamama.Models
{
    public partial class User
    {
        public User()
        {
            ActualIntencive = new HashSet<ActualIntencive>();
            ExpectedIntencive = new HashSet<ExpectedIntencive>();
            Invoice = new HashSet<Invoice>();
            NotificationReciever = new HashSet<Notification>();
            NotificationSender = new HashSet<Notification>();
            Target = new HashSet<Target>();
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
        public virtual ICollection<ActualIntencive> ActualIntencive { get; set; }
        public virtual ICollection<ExpectedIntencive> ExpectedIntencive { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
        public virtual ICollection<Notification> NotificationReciever { get; set; }
        public virtual ICollection<Notification> NotificationSender { get; set; }
        public virtual ICollection<Target> Target { get; set; }
        public virtual ICollection<Visit> Visit { get; set; }
    }
}
