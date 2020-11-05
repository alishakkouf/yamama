using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yamama.Repository;


namespace Yamama.Services
{
    public class InvoiceService : I_Invoice
    {

        private readonly yamamadbContext _db;
        public InvoiceService(yamamadbContext db)
        {
            _db = db;
        }
        public async Task<int> DeleteInvoiceAsync(int id)
        {
            int result = 0;
            //check if the dbcontext is not null
            if (_db != null)
            {
                // if not find the specified invoice
                var invoice = await _db.Invoice.FirstOrDefaultAsync(p => p.Idinvoice == id);

                //check the returned value is not null
                if (invoice != null)
                    // if it not null delete the specified invoice
                _db.Invoice.Remove(invoice);

                //commit the changes on database
                await _db.SaveChangesAsync();
                //if the operation succecced return 1
                result += 1;
                return result;
            }
            return result;
        }
        public async Task<Invoice> GetInvoice(int id)
        {
            //get all invoices
            return await _db.Invoice.FirstOrDefaultAsync(f => f.Idinvoice == id);
        }
        public async Task<List<Invoice>> GetInvoices()
        {
            //check if the dbcontext is not null
            if (_db != null)
            {
                // if not find all invoices
                return await _db.Invoice.ToListAsync();
            }
            return null;
        }
    }
}
