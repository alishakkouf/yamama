using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yamama.Models;
using Yamama.ViewModels;

namespace Yamama.Repository
{
    public interface ICart
    {
        Task<List<Cart>> AddCartAsync(InvoiceCartViewModel invoiceCart, int id);
    }
}
