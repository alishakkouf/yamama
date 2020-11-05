using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yamama.Repository;
using Yamama.ViewModels;

namespace Yamama.Services
{
    public class CartService : ICart
    {

        private readonly yamamadbContext _db;
        public CartService(yamamadbContext db)
        {
            _db = db;
        }

        // add cart
        public async Task<List<Cart>> AddCartAsync(ImportCartInvoiceViewModel impoInvoice, int id)
        {
            try
            {
                Double fullcost = 0;
                for (int i = 0; i < impoInvoice.listcart.Count; i++)
                {
                    impoInvoice.listcart[i].InvoiceId = id;

                    fullcost += Convert.ToDouble(impoInvoice.listcart[i].Price);

                    await _db.Cart.AddAsync(impoInvoice.listcart[i]);

                    await _db.SaveChangesAsync();
                }
                return impoInvoice.listcart;
            }
            catch (Exception)
            {

                return null;
            }

        }      
    }
}
