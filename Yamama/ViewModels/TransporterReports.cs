using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yamama.ViewModels
{
    public class TransporterReports
    {
        public int product { get; set; }
        public int client { get; set; }
        public int Qty { get; set; }
        public DateTime date { get; set; }
        public int TransporterClient { get; set; }
        public int ID_invoice { get; set; }
    }
}
