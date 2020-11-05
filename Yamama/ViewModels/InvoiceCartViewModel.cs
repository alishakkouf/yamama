using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yamama.Models;

namespace Yamama.ViewModels
{
    public class InvoiceCartViewModel
    {
        public Invoice invoice { get; set; }
           
        public List<Cart> listcart { get; set; }
        
    }
}
