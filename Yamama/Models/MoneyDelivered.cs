using System;
using System.Collections.Generic;

namespace Yamama
{
    public partial class MoneyDelivered
    {
        public int IdmoneyDelivered { get; set; }
        public double Amount { get; set; }
        public DateTime? FirstDate { get; set; }
        public int InvoiceId { get; set; }
        public int? FId { get; set; }
        public int? PId { get; set; }
        public string State { get; set; }

        public virtual Factory F { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual Project P { get; set; }
    }
}
