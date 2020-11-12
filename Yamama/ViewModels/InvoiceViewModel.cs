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
        public Double FullCost { get; set; }
        public string project { get; set; }
        public Double Paid { get; set; }
        public Double Remain_yamama { get; set; }
        public Double Remain_customer { get; set; }
        public string Type { get; set; }
        public string FullName { get; set; }
    }
}
