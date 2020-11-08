using System;
using System.Collections.Generic;
//using Yamama.Models;

namespace Yamama
{
    public partial class Store
    {
        public int Idstore { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
    }
}
