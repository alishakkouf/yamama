using System;
using System.Collections.Generic;

namespace Yamama
{
    public partial class Target
    {
        public int Idtarget { get; set; }
        public string SalesmanId { get; set; }
        public int? Visits { get; set; }
        public int? Sales { get; set; }
        public DateTime? Date { get; set; }

        public virtual Aspnetusers Salesman { get; set; }
    }
}
