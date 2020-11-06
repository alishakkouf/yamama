using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yamama.ViewModels
{
    public class BalanceViewModel
    {
        public int? ProductId { get; set; }
        public int? FirstPeriod { get; set; }
        public int? LastPeriod { get; set; }
        public DateTime? DateOfFirst { get; set; }

        public DateTime? DateOfLast { get; set; }
        public int Quantity { get; set; }

    }
}
