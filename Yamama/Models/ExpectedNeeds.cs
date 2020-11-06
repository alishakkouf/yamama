using System;
using System.Collections.Generic;

namespace Yamama.Models
{
    public partial class ExpectedNeeds
    {
        public int IdexptedNeeds { get; set; }
        public int? ExpectedNeeds1 { get; set; }
        public DateTime? Date { get; set; }
        public int? ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
