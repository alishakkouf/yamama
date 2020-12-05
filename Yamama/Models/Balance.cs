﻿using System;
using System.Collections.Generic;

namespace Yamama
{
    public partial class Balance
    {
        public int Idbalance { get; set; }
        public int? ProductId1 { get; set; }
        public int? FirstPeriod { get; set; }
        public DateTime? DateOfFirst { get; set; }
        public int? LastPeriod { get; set; }
        public DateTime? DateOfLast { get; set; }

        public virtual Product ProductId1Navigation { get; set; }
    }
}
