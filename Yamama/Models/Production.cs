using System;
using System.Collections.Generic;

namespace Yamama
{
    public partial class Production
    {
        public int Idproduction { get; set; }
        public int? ProductId { get; set; }
        public string Quantity { get; set; }
        public DateTime? Date { get; set; }

        public virtual Product Product { get; set; }
    }
}
