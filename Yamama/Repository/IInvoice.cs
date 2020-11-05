using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yamama.Models;
using Yamama.ViewModels;

namespace Yamama.Repository
{
    public interface IInvoice
    {
        Task<Invoice> AddInvoiceAsync(InvoiceCartViewModel invoiceCart);
    }
}
