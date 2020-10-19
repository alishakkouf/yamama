using System;
using System.Collections.Generic;

namespace Yamama.Models
{
    public partial class TaskStatus
    {
        public TaskStatus()
        {
            Task = new HashSet<Task>();
        }

        public int IdtaskStatus { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Task> Task { get; set; }
    }
}
