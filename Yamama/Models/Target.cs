using System;
using System.Collections.Generic;

namespace Yamama.Models
{
    public partial class Target
    {
        public int Idtarget { get; set; }
        public int SalesmanId { get; set; }
        public int? Visits { get; set; }
        public int? Sales { get; set; }
        public DateTime? Date { get; set; }

        
    }
}
