using System;
using System.Collections.Generic;

namespace Yamama
{
    public partial class Invoice
    {
        public Invoice()
        {
            Cart = new HashSet<Cart>();
        }

        public int Idinvoice { get; set; }
        public int? FactoryId { get; set; }
        public DateTime? Date { get; set; }
        public double? FullCost { get; set; }
        public int? ProjectId { get; set; }
        public double? Paid { get; set; }
        public double? RemainForYamama { get; set; }
        public double? RemainForCustomer { get; set; }
        public string Type { get; set; }
        public string Supplier { get; set; }

        public virtual Factory Factory { get; set; }
        public virtual Project Project { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
    }
}
