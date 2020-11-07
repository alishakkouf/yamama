﻿using System;
using System.Collections.Generic;

namespace Yamama.Models
{
    public partial class Product
    {
        public Product()
        {
            Balance = new HashSet<Balance>();
            Cart = new HashSet<Cart>();
            Production = new HashSet<Production>();
            Store = new HashSet<Store>();

            ActualNeeds = new HashSet<ActualNeeds>();

            ExpectedNeeds = new HashSet<ExpectedNeeds>();
            Production = new HashSet<Production>();

        }

        public int Idproduct { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }



        public virtual ICollection<Balance> Balance { get; set; }

        public virtual ICollection<ActualNeeds> ActualNeeds { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<ExpectedNeeds> ExpectedNeeds { get; set; }
        public virtual ICollection<Production> Production { get; set; }
        public virtual ICollection<Store> Store { get; set; }
    }
}
        
