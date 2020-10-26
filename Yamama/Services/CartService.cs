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
        private readonly yamamadbContext _yamamadbContext;
        public CartService(yamamadbContext yamamadbContext)
        {
            _yamamadbContext = yamamadbContext;
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

                    await _yamamadbContext.Cart.AddAsync(invoiceCart.listcart[i]);

                    await _yamamadbContext.SaveChangesAsync();
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