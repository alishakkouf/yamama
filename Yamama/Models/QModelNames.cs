using System;
using System.Collections.Generic;

namespace Yamama
{
    public partial class QModelNames
    {
        public QModelNames()
        {
            Questions = new HashSet<Questions>();
        }

        public int IdqModelNames { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Questions> Questions { get; set; }
    }
}
