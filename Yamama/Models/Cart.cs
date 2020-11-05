using System;
using System.Collections.Generic;

namespace Yamama.Models
{
    public partial class Cart
    {
        public int Idcart { get; set; }
        public int? ProductId { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public double? SubCost { get; set; }
        public int? InvoiceId { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual Product Product { get; set; }
    }
}
