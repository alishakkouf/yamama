using System;
using System.Collections.Generic;

namespace Yamama.Models
{
    public partial class ActualNeeds
    {
        public int IdactualNeeds { get; set; }
        public int? ActualNeeds1 { get; set; }
        public DateTime? Date { get; set; }
        public int? ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
