using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yamama.Models;
using Yamama.Repository;
using Yamama.ViewModels;

namespace Yamama.Services
{
    public class InvoiceServices : IInvoice
    {
        private readonly yamamadbContext _db;

        public InvoiceServices(yamamadbContext db)
        {
            _db = db;
        }
        public async Task<Invoice> AddInvoiceAsync(InvoiceCartViewModel invoiceCart)
        {
            try
            {
                if (invoiceCart.invoice.Paid < invoiceCart.invoice.FullCost)
                {
                    invoiceCart.invoice.RemainForYamama = invoiceCart.invoice.FullCost - invoiceCart.invoice.Paid;
                }
                else if (invoiceCart.invoice.Paid > invoiceCart.invoice.FullCost)
                {
                    invoiceCart.invoice.RemainForCustomer = invoiceCart.invoice.Paid - invoiceCart.invoice.FullCost;
                }
                else
                {
                    invoiceCart.invoice.RemainForCustomer = invoiceCart.invoice.RemainForYamama = 0;
                }

                await _db.Invoice.AddAsync(invoiceCart.invoice);
                await _db.SaveChangesAsync();

                //get id for this invoice

                var RecentInvoice = _db.Invoice.OrderByDescending(p => p.Idinvoice).FirstOrDefault();
                int RecentInvoiceID = RecentInvoice.Idinvoice;

                //********await _cart.AddCartAsync(invoiceCart, RecentInvoiceID); ********

                    return invoiceCart.invoice;
            }
            catch
            {
                return null;
            }
        }

    }
}
