using System;
using System.Collections.Generic;

namespace Yamama
{
    public partial class Product
    {
        public Product()
        {
            Production = new HashSet<Production>();
        }

        public int Idproduct { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<Production> Production { get; set; }
    }
}
