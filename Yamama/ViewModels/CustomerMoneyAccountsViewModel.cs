using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yamama.ViewModels
{
    public class CustomerMoneyAccountsViewModel
    {
        public string Client { get; set; }
        public Double? MoneyForClient { get; set; }
        public Double? MoneyForYamama { get; set; }
    }
}
