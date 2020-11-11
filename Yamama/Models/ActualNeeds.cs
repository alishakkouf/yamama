using System;
using System.Collections.Generic;

namespace Yamama
{
    public partial class ActualNeeds
    {
        public int IdactualNeeds { get; set; }
        public int? ActualNeeds1 { get; set; }
        public DateTime? Date { get; set; }
        public int? IdProduct { get; set; }

        public virtual Product IdProductNavigation { get; set; }
    }
}
