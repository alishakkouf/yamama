using System;
using System.Collections.Generic;

namespace Yamama.Models
{
    public partial class Photo
    {
        public Photo()
        {
            Task = new HashSet<Task>();
        }

        public int Idphoto { get; set; }
        public string Path { get; set; }
        public int? ProjectId { get; set; }
        public string Name { get; set; }

        public virtual Project Project { get; set; }
        public virtual ICollection<Task> Task { get; set; }
    }
}
