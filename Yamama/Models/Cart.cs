using System;
using System.Collections.Generic;

namespace Yamama
{
    public partial class Cart
    {
        public int IdCart { get; set; }
        public int? ProductId { get; set; }
        public double? Price { get; set; }
        public int Qty { get; set; }
        public double? SubCost { get; set; }
        public int InvoiceId { get; set; }
        public int? TransportedId { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual Product Product { get; set; }
        public virtual Transporter Transported { get; set; }
    }
}
