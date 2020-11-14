using System;
using System.Collections.Generic;

namespace Yamama
{
    public partial class Aspnetusers
    {
        public Aspnetusers()
        {
            ActualIntencive = new HashSet<ActualIntencive>();
            AlertReciever = new HashSet<Alert>();
            AlertSender = new HashSet<Alert>();
            Aspnetuserclaims = new HashSet<Aspnetuserclaims>();
            Aspnetuserlogins = new HashSet<Aspnetuserlogins>();
            Aspnetuserroles = new HashSet<Aspnetuserroles>();
            Aspnetusertokens = new HashSet<Aspnetusertokens>();
            ExpectedIntencive = new HashSet<ExpectedIntencive>();
            Invoice = new HashSet<Invoice>();
            NotificationReceiver = new HashSet<Notification>();
            NotificationSender = new HashSet<Notification>();
            RequestInformationReciever = new HashSet<RequestInformation>();
            RequestInformationSender = new HashSet<RequestInformation>();
            Target = new HashSet<Target>();
            TaskCreator = new HashSet<Task>();
            TaskResponsible = new HashSet<Task>();
            Visit = new HashSet<Visit>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string FullName { get; set; }

        public virtual ICollection<ActualIntencive> ActualIntencive { get; set; }
        public virtual ICollection<Alert> AlertReciever { get; set; }
        public virtual ICollection<Alert> AlertSender { get; set; }
        public virtual ICollection<Aspnetuserclaims> Aspnetuserclaims { get; set; }
        public virtual ICollection<Aspnetuserlogins> Aspnetuserlogins { get; set; }
        public virtual ICollection<Aspnetuserroles> Aspnetuserroles { get; set; }
        public virtual ICollection<Aspnetusertokens> Aspnetusertokens { get; set; }
        public virtual ICollection<ExpectedIntencive> ExpectedIntencive { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
        public virtual ICollection<Notification> NotificationReceiver { get; set; }
        public virtual ICollection<Notification> NotificationSender { get; set; }
        public virtual ICollection<RequestInformation> RequestInformationReciever { get; set; }
        public virtual ICollection<RequestInformation> RequestInformationSender { get; set; }
        public virtual ICollection<Target> Target { get; set; }
        public virtual ICollection<Task> TaskCreator { get; set; }
        public virtual ICollection<Task> TaskResponsible { get; set; }
        public virtual ICollection<Visit> Visit { get; set; }
    }
}
