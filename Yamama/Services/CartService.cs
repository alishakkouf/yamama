using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yamama;
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
                //store invoice full_cost
                //Double fullcost = 0;

                for (int i = 0; i < invoiceCart.listcart.Count; i++)
                {
                    //assign every item in the invoice with it's invoice_id
                    invoiceCart.listcart[i].InvoiceId = id;

                    //fullcost += Convert.ToDouble(invoiceCart.listcart[i].Price);

                    await _yamamadbContext.Cart.AddAsync(invoiceCart.listcart[i]);

                    await _yamamadbContext.SaveChangesAsync();

                    var store = _yamamadbContext.Store.Where(x => x.ProductId == invoiceCart.listcart[i].ProductId).SingleOrDefault();
                    if (invoiceCart.invoice.Type == "Purchses" || invoiceCart.invoice.Type == "import")
                    {

                        if (store != null)
                        {
                            store.Quantity += invoiceCart.listcart[i].Qty;
                            _yamamadbContext.Store.Update(store);
                            _yamamadbContext.SaveChanges();
                        }
                        else
                        {
                            Store newStore = new Store
                            {
                                ProductId = invoiceCart.listcart[i].ProductId,
                                Quantity = invoiceCart.listcart[i].Qty,
                                Name = _yamamadbContext.Product.Where(x => x.Idproduct == invoiceCart.listcart[i].ProductId).Select(x => x.Name).SingleOrDefault()
                            };
                            _yamamadbContext.Store.Add(store);
                            _yamamadbContext.SaveChanges();
                        }

                    }
                    else if(invoiceCart.invoice.Type == "sell" || invoiceCart.invoice.Type == "export")
                    {
                        if (store != null)
                        {

                            store.Quantity -= invoiceCart.listcart[i].Qty;
                            _yamamadbContext.Store.Update(store);
                            _yamamadbContext.SaveChanges();
                        }
                    
                         
                    }


                }
                return invoiceCart.listcart;
            }
            catch (Exception)
            {

                return null;
            }


        }

        public async Task<int> addMoneyCashes(InvoiceCartViewModel invoiceCart, int recentInvoiceID)
        {
            int result = 0;
            try
            {
              
                Invoice lastInvoice = _yamamadbContext.Invoice.Where(x => x.Idinvoice == recentInvoiceID).SingleOrDefault();
                List<MoneyDelivered> moneyCashes = invoiceCart.Money;
                for (int i = 0; i < moneyCashes.Count; i++)
                {
                 
                    moneyCashes[i].InvoiceId = recentInvoiceID;
                    if (lastInvoice.FactoryId != null )
                    {
                        moneyCashes[i].FId = lastInvoice.FactoryId;
                    }
                    else
                    {
                        moneyCashes[i].PId = lastInvoice.ProjectId;
                    }                 
                    moneyCashes[i].Amount = invoiceCart.Money[i].Amount;
                    moneyCashes[i].FirstDate = invoiceCart.Money[i].FirstDate;
                    moneyCashes[i].State = invoiceCart.Money[i].State;

                    await _yamamadbContext.MoneyDelivered.AddAsync(moneyCashes[i]);
                    await _yamamadbContext.SaveChangesAsync();
                    result = 1;
                }
                return result;
            }
            catch (Exception)
            {

                return result;
            }
        }

        // add cart
       
    }
}
