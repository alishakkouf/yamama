using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yamama.ViewModels
{
    public class StoreViewModel
    {
        public List<Cart> listcart { get; set; }
        public Invoice invoice { get; set; }

        public Production production { get; set; }

        public Store store { get; set; }

    }
}
