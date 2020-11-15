using System;
using System.Collections.Generic;

namespace Yamama
{
    public partial class Store
    {
        public int Idstore { get; set; }
        public string Name { get; set; }
        public int? ProId { get; set; }
        public Double Quantity { get; set; }

        public virtual Product Pro { get; set; }
    }
}
