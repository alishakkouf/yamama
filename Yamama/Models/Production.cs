using System;
using System.Collections.Generic;

namespace Yamama.Models
{
    public partial class Production
    {
        public int Idproduction { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public DateTime? Date { get; set; }

        public virtual Product Product { get; set; }
    }
}
