using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yamama.ViewModels
{
    public class InvoiceViewModel
    {
        public string factory { get; set; }
        public DateTime? Date { get; set; }
        public double? FullCost { get; set; }
        public string project { get; set; }
        public double? Paid { get; set; }
        public double? Remain_yamama { get; set; }
        public double? Remain_customer { get; set; }
        public string Type { get; set; }
        public string FullName { get; set; }
    }
}
