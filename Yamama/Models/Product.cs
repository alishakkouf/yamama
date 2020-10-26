using System;
using System.Collections.Generic;

namespace Yamama
{
    public partial class Product
    {
        public Product()
        {
            Cart = new HashSet<Cart>();
        }

        public int Idproduct { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<Cart> Cart { get; set; }
    }
}
