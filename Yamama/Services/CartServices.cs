using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yamama.Models;
using Yamama.Repository;
using Yamama.ViewModels;

namespace Yamama.Services
{
    public class CartServices : ICart
    {
        private readonly yamamaContext _db;

        public CartServices(yamamaContext db)
        {
            _db = db;
        }
        public async Task<List<Cart>> AddCartAsync(InvoiceCartViewModel invoiceCart, int id)
        {
            try
            {
                Double fullcost = 0;
                for (int i = 0; i < invoiceCart.listcart.Count; i++)
                {
                    invoiceCart.listcart[i].InvoiceId = id;

                    fullcost += Convert.ToDouble(invoiceCart.listcart[i].Price);

                    await _db.Cart.AddAsync(invoiceCart.listcart[i]);

                    await _db.SaveChangesAsync();
                }
                return invoiceCart.listcart;
            }
            catch (Exception)
            {

                return null;
            }

        }
    }
}
