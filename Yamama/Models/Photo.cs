using System;
using System.Collections.Generic;

namespace Yamama
{
    public partial class Photo
    {
        public int Idphoto { get; set; }
        public string Path { get; set; }
        public int? ProjectId { get; set; }
        public string Name { get; set; }

        public virtual Project Project { get; set; }
    }
}
