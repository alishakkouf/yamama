using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yamama.Repository
{
     public interface I_Invoice
    {
        Task<List<Invoice>> GetInvoices();
        Task<Invoice> GetInvoice(int id);
        Task<int> DeleteInvoiceAsync(int id);
    }
}
