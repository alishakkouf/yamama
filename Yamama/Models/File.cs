using System;
using System.Collections.Generic;

namespace Yamama.Models
{
    public partial class File
    {
        public File()
        {
            Alert = new HashSet<Alert>();
            RequestInformation = new HashSet<RequestInformation>();
            Task = new HashSet<Task>();
        }

        public int Idfile { get; set; }
        public string ParentType { get; set; }
        public int? ParentId { get; set; }
        public string Path { get; set; }

        public virtual ICollection<Alert> Alert { get; set; }
        public virtual ICollection<RequestInformation> RequestInformation { get; set; }
        public virtual ICollection<Task> Task { get; set; }
    }
}
