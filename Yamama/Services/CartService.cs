﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yamama;
using Yamama.Models;
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
                Double fullcost = 0;

                for (int i = 0; i < invoiceCart.listcart.Count; i++)
                {
                    //assign every item in the invoice with it's invoice_id
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
        public async Task<List<Cart>> AddCartAsync(ImportCartInvoiceViewModel impoInvoice, int id)
        {
            try
            {
                Double fullcost = 0;
                for (int i = 0; i < impoInvoice.listcart.Count; i++)
                {
                    impoInvoice.listcart[i].InvoiceId = id;

                    fullcost += Convert.ToDouble(impoInvoice.listcart[i].Price);

                    await _yamamadbContext.Cart.AddAsync(impoInvoice.listcart[i]);

                    await _yamamadbContext.SaveChangesAsync();
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
