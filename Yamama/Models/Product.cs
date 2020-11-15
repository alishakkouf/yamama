using System;
using System.Collections.Generic;

namespace Yamama
{
    public partial class Product
    {
        public Product()
        {
            ActualNeeds = new HashSet<ActualNeeds>();
            Balance = new HashSet<Balance>();
            Cart = new HashSet<Cart>();
            ExpectedNeeds = new HashSet<ExpectedNeeds>();
            Factory = new HashSet<Factory>();
            Production = new HashSet<Production>();
            Store = new HashSet<Store>();
        }

        public int Idproduct { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public virtual ICollection<ActualNeeds> ActualNeeds { get; set; }
        public virtual ICollection<Balance> Balance { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<ExpectedNeeds> ExpectedNeeds { get; set; }
        public virtual ICollection<Factory> Factory { get; set; }
        public virtual ICollection<Production> Production { get; set; }
        public virtual ICollection<Store> Store { get; set; }
    }
}
