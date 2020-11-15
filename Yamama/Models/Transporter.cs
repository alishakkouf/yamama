using System;
using System.Collections.Generic;

namespace Yamama
{
    public partial class Transporter
    {
        public Transporter()
        {
            Cart = new HashSet<Cart>();
            Factory = new HashSet<Factory>();
        }

        public int Idtransporter { get; set; }
        public string Name { get; set; }
        public string TransporterNum { get; set; }

        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<Factory> Factory { get; set; }
    }
}
