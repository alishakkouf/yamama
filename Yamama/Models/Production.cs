﻿using System;
using System.Collections.Generic;

namespace Yamama
{
    public partial class Production
    {
        public int Idproduction { get; set; }
        public int? IdProduct { get; set; }
        public int? Quantity { get; set; }
        public DateTime? Date { get; set; }

        public virtual Product IdProductNavigation { get; set; }
    }
}
