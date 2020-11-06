using System;
using System.Collections.Generic;

namespace Yamama.Models
{
    public partial class Store
    {
        public int Idstor { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }

        public virtual Product Product { get; set; }
    }
}
