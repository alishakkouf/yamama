using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yamama.ViewModels;

namespace Yamama.Repository
{
    public interface ICart
    {
        //insert invoice's items into database 
        Task<List<Cart>> AddCartAsync(InvoiceCartViewModel invoiceCart, int id);

        //insert cashes into database 
        Task<int> addMoneyCashes(InvoiceCartViewModel invoiceCart, int recentInvoiceID);


        
       
    }
}
