using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yamama.ViewModels
{
    public class TransporterReports
    {
        public string product { get; set; }
        public string client { get; set; }
        public Double Qty { get; set; }
        public DateTime date { get; set; }
        public string TransporterClient { get; set; }
        public int ID_invoice { get; set; }
    }
}
