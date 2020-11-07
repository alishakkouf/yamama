using System;
using System.Collections.Generic;
using Yamama.Models;

namespace Yamama
{
    public partial class Task
    {
        public Task()
        {
            Alert = new HashSet<Alert>();
            RequestInformation = new HashSet<RequestInformation>();
            Visit = new HashSet<Visit>();
        }

        public int Idtask { get; set; }
        public string Name { get; set; }
        public int? TypeId { get; set; }
        public int? StatusId { get; set; }
        public int? ResponsibleId { get; set; }
        public int? CreatorId { get; set; }
        public string Content { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? FileId { get; set; }
        public int? PhotoId { get; set; }

        public virtual File File { get; set; }
        public virtual Photo Photo { get; set; }
        public virtual TaskStatus Status { get; set; }
        public virtual TaskType Type { get; set; }
        public virtual ICollection<Alert> Alert { get; set; }
        public virtual ICollection<RequestInformation> RequestInformation { get; set; }
        public virtual ICollection<Visit> Visit { get; set; }
    }
}
