using System;
using System.Collections.Generic;

namespace Yamama.Models
{
    public partial class TaskType
    {
        public TaskType()
        {
            Task = new HashSet<Task>();
        }

        public int IdtaskType { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Task> Task { get; set; }
    }
}
