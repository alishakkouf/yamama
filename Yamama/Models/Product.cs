using System;
using System.Collections.Generic;

namespace Yamama.Models
{
    public partial class Product
    {
        public Product()
        {
            ActualNeeds = new HashSet<ActualNeeds>();
            Cart = new HashSet<Cart>();
            ExpectedNeeds = new HashSet<ExpectedNeeds>();
            Production = new HashSet<Production>();
            Store = new HashSet<Store>();
        }

        public int Idproduct { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<ActualNeeds> ActualNeeds { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<ExpectedNeeds> ExpectedNeeds { get; set; }
        public virtual ICollection<Production> Production { get; set; }
        public virtual ICollection<Store> Store { get; set; }
    }
}
