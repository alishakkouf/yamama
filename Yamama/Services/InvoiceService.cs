using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Yamama.Repository;
using Yamama.ViewModels;

namespace Yamama.Services
{
    public class InvoiceService : IInvoicecs
    {
        private readonly yamamadbContext _yamamadbContext;
        private readonly ICart _cart;

        public InvoiceService(yamamadbContext yamamadbContext, ICart cart)
        {
            _yamamadbContext = yamamadbContext;
            _cart = cart;
        }

        public async Task<int> DeleteInvoiceAsync(int IdInvoice)
        {
            int result = 0;
            //Find the invoice for specific id
            var invoice = await _yamamadbContext.Invoice.FirstOrDefaultAsync(x => x.Idinvoice == IdInvoice);

            if (invoice != null)
            {
                //Delete that invoice

                _yamamadbContext.Invoice.Remove(invoice);

                //Commit the transaction
                await _yamamadbContext.SaveChangesAsync();

                result += 1;
                return result;
            }
            return result;

        }
        

        public async Task<List<Invoice>> GetInvoicesAsync()
            {
                return await _yamamadbContext.Invoice.ToListAsync();

            }

        
       public async Task<Invoice> GetInvoice(int IdInvoice)
            {
                return await _yamamadbContext.Invoice.FirstOrDefaultAsync(x => x.Idinvoice == IdInvoice);
            }

       public async  Task<InvoiceCartViewModel> getInvoiceDetailes(int invoiceId)
            {
            if (_yamamadbContext != null)
            {

                InvoiceCartViewModel invoiceCartViewModel = new InvoiceCartViewModel();

                try
                {


                    //get items from invoice table according to invoice_id
                    Invoice invoiceInfo = await GetInvoice(invoiceId);
               

                    //check if there is invoice with this is
                    if (invoiceInfo == null) return null;

                invoiceCartViewModel.invoice = invoiceInfo;

                //get items from cart table according to invoice_id
                List<Cart> cartInfo = await (from helper in _yamamadbContext.Cart
                                             where helper.InvoiceId == invoiceId
                                             select new Cart
                                             {
                                                 ProductId = helper.ProductId,
                                                 Qty =helper.Qty,
                                                 Price =helper.Price,
                                                 SubCost =helper.SubCost
                                             }).ToListAsync();
                                      
                                     
                invoiceCartViewModel.listcart = cartInfo;

                return invoiceCartViewModel;
                }
                catch (Exception)
                {

                    return null;
                }
            }

            return null;
        }

        public async Task<List<Invoice>> GetInvoiceDetailesForClient(int FactoryId , int ProjectId)
        {
            if (_yamamadbContext != null)
            {               
                try
                {
                    //get items from invoice table according to Factory_id
                    if (FactoryId != 0)
                    {
                        List<Invoice> invoiceInfo =  _yamamadbContext.Invoice.Where(x => x.FactoryId == FactoryId).ToList();
                        return invoiceInfo;
                    }
                    else   //get items from invoice table according to Project_id
                    if (FactoryId != 0)
                    {
                        List<Invoice> invoiceInfo = _yamamadbContext.Invoice.Where(x => x.ProjectId == ProjectId).ToList();
                        return invoiceInfo;
                    }                                   
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return null;
        }

        public async Task<Invoice> AddInvoiceAsync(InvoiceCartViewModel invoiceCart)
            {
                try
                {
                if (invoiceCart.invoice.Paid < invoiceCart.invoice.FullCost)
                {
                    invoiceCart.invoice.RemainForYamama = invoiceCart.invoice.FullCost - invoiceCart.invoice.Paid;
                }
                else if(invoiceCart.invoice.Paid > invoiceCart.invoice.FullCost)
                {
                    invoiceCart.invoice.RemainForCustomer = invoiceCart.invoice.Paid - invoiceCart.invoice.FullCost;
                }
                else
                {
                    invoiceCart.invoice.RemainForCustomer = invoiceCart.invoice.RemainForYamama = 0;
                }
                
                    await _yamamadbContext.Invoice.AddAsync(invoiceCart.invoice);
                    await _yamamadbContext.SaveChangesAsync();

                    //get id for this invoice

                    var RecentInvoice = _yamamadbContext.Invoice.OrderByDescending(p => p.Idinvoice).FirstOrDefault();
                    int RecentInvoiceID = RecentInvoice.Idinvoice;

                    await _cart.AddCartAsync(invoiceCart, RecentInvoiceID);

                    return invoiceCart.invoice;
                }
                catch
                {
                    return null;
                }
            }

        public async Task<List<Double>> GetSalesReports(string period, DateTime start, DateTime end)
        {
            try
            {
                if (period == "daily")
                {
                    //Define list of invoices to store the result
                    List<Double> result = new List<double>();
                    System.TimeSpan diff = end.Subtract(start);
                    for (var day = start.Date; day <= end; day = day.AddDays(1))
                    {
                        //to store the full sales
                        Double value = 0;

                        string test = day.ToString("yyyy-MM-dd");
                        //return list of id_invoices in each day
                        List<int> invoicesNumbers = _yamamadbContext.Invoice.Where(x => x.Date.ToString() == test).Select(x => x.Idinvoice).ToList();

                        for (int j = 0; j < invoicesNumbers.Count; j++)
                        {
                            InvoiceCartViewModel subResult = await getInvoiceDetailes(invoicesNumbers[j]);
                            value += Convert.ToDouble(subResult.invoice.FullCost.Value);

                        }
                        result.Add(value);
                    }


                    return result;
                }
                else if (period == "monthly")
                {
                    //Define list of invoices to store the result
                    List<Double> result = new List<double>();
                    System.TimeSpan diff = end.Subtract(start);
                    for (var month = start.Month; month <= end.Month; month++)
                    {
                        //to store the full sales
                        Double value = 0;

                        //return list of id_invoices in each day
                        List<int> invoicesNumbers = _yamamadbContext.Invoice.Where(x => x.Date.Value.Month == month).Select(x => x.Idinvoice).ToList();

                        for (int j = 0; j < invoicesNumbers.Count; j++)
                        {
                            InvoiceCartViewModel subResult = await getInvoiceDetailes(invoicesNumbers[j]);
                            value += Convert.ToDouble(subResult.invoice.FullCost.Value);

                        }
                        result.Add(value);
                    }


                    return result;
                }
                else if (period == "annual")
                {
                    //Define list of invoices to store the result
                    List<Double> result = new List<double>();
                    System.TimeSpan diff = end.Subtract(start);
                    for (var year = start.Year; year <= end.Year; year++)
                    {
                        //to store the full sales
                        Double value = 0;

                        //return list of id_invoices in each day
                        List<int> invoicesNumbers = _yamamadbContext.Invoice.Where(x => x.Date.Value.Year == year).Select(x => x.Idinvoice).ToList();

                        for (int j = 0; j < invoicesNumbers.Count; j++)
                        {
                            InvoiceCartViewModel subResult = await getInvoiceDetailes(invoicesNumbers[j]);
                            value += Convert.ToDouble(subResult.invoice.FullCost.Value);

                        }
                        result.Add(value);
                    }


                    return result;
                }
                //else if (period == "weekly")
                //{
                //    //Define list of invoices to store the result
                //    List<Double> result = new List<double>();
                //    Double diff = (end - start).TotalDays;

                //    var fromDay = start.DayOfWeek;
                //    if (fromDay <= DayOfWeek.Saturday)
                //    { Double duration = DayOfWeek.Saturday - fromDay;
                //        diff = diff + duration; }
                //    else
                //    { Double duration = DayOfWeek.Saturday - fromDay;
                //        diff = diff + duration; }

                   



                //    for (var year = start.Year; year <= end.Year; year++)
                //    {
                //        //to store the full sales
                //        Double value = 0;

                //        //return list of id_invoices in each day
                //        List<int> invoicesNumbers = _yamamadbContext.Invoice.Where(x => x.Date.Value.Year == year).Select(x => x.Idinvoice).ToList();

                //        for (int j = 0; j < invoicesNumbers.Count; j++)
                //        {
                //            InvoiceCartViewModel subResult = await getInvoiceDetailes(invoicesNumbers[j]);
                //            value += Convert.ToDouble(subResult.invoice.FullCost.Value);

                //        }
                //        result.Add(value);
                //    }


                //    return result;
                //}

                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<List<MoneyAndQuantity>> GetSalesReportsClientCement(int factory, int project, string CementType, string period, DateTime from, DateTime end)
        {
            if (_yamamadbContext != null)
            {
                try
                {
                    //int client = 0;
                    //if(factory != 0) { client = factory; } else { client = project; }
                    //get the id for the CementType
                    int Cement_ID = _yamamadbContext.Product.Where(x => x.Name == CementType).Select(x=>x.Idproduct).SingleOrDefault();

                    

                    List<InvoiceAndQuantity> InvoiceAndQty = new List<InvoiceAndQuantity>();

                    //get list of integer (invoices_Id ) from Cart table according to cement_id
                    List<int> InvoicesID =  _yamamadbContext.Cart.Where(x => x.ProductId == Cement_ID).Select(x=>x.InvoiceId).Distinct().ToList();

                    for (int k = 0; k < InvoicesID.Count; k++)
                    {
                        int subQty = await _yamamadbContext.Cart.Where(x => x.InvoiceId == InvoicesID[k]).Select(x => x.Qty).SumAsync();
                        InvoiceAndQuantity invoiceAndQuantity = new InvoiceAndQuantity();
                        invoiceAndQuantity.Qty = subQty;
                        invoiceAndQuantity.CartInvoiceId = InvoicesID[k];
                        InvoiceAndQty.Add(invoiceAndQuantity);
                    }

                    if (period == "daily")
                    {
                        //Define list of Double to store the result
                        List<MoneyAndQuantity> result = new List<MoneyAndQuantity>();
                        
                        for (var day = from.Date; day <= end; day = day.AddDays(1))
                        {
                            //to store the full sales for each day
                            Double value = 0;
                            //to store the full Quantities for each day
                            Double Quantity = 0;

                            //list of id_invoices in each day which deal with the conditions
                            List<int> invoicesNumbers = new List<int>();

                            string test = day.ToString("yyyy-MM-dd");

                            for (int i = 0; i < InvoiceAndQty.Count; i++)
                            {

                                if (factory != 0)
                                {

                                    int one = await _yamamadbContext.Invoice.Where(x => x.Idinvoice == InvoiceAndQty[i].CartInvoiceId &&
                                                                                                x.Date.ToString() == test &&
                                                                                                 x.FactoryId == factory)
                                                                                                 .Select(x => x.Idinvoice).SingleOrDefaultAsync();
                                    if (one != 0) { invoicesNumbers.Add(one); } else continue;
                                }
                                else
                                {
                                    int one = await _yamamadbContext.Invoice.Where(x => x.Idinvoice == InvoiceAndQty[i].CartInvoiceId &&
                                                                                            x.Date.ToString() == test &&
                                                                                             x.ProjectId == project)
                                                                                             .Select(x => x.Idinvoice).SingleOrDefaultAsync();
                                    invoicesNumbers.Add(one);
                                }
                            }

                            for (int j = 0; j < invoicesNumbers.Count; j++)
                            {
                                Invoice subResult = await GetInvoice(invoicesNumbers[j]);
                                value += Convert.ToDouble(subResult.FullCost.Value);

                                for (int a = 0; a < InvoiceAndQty.Count; a++)
                                {
                                    if (invoicesNumbers[j] == InvoiceAndQty[a].CartInvoiceId)
                                    {
                                        Quantity += InvoiceAndQty[a].Qty;
                                    }
                                    else continue;
                                }

                            }
                            MoneyAndQuantity moneyAndQuantity = new MoneyAndQuantity();
                            moneyAndQuantity.Money = value;
                            moneyAndQuantity.Quantity = Quantity;
                            result.Add(moneyAndQuantity);

                        }


                        return result;
                    }
                    if (period == "monthly")
                    {
                        //Define list of Double to store the result
                        List<MoneyAndQuantity> result = new List<MoneyAndQuantity>();

                        for (var month = from.Month; month <= end.Month; month++)
                        {
                            //to store the full sales
                            Double value = 0;
                            //to store the full Quantities for each day
                            Double Quantity = 0;

                            //list of id_invoices in each day
                            List<int> invoicesNumbers = new List<int>();

                            //string test = day.ToString("yyyy-MM-dd");

                            for (int i = 0; i < InvoicesID.Count; i++)
                            {

                                if (factory != 0)
                                {

                                    int one = await _yamamadbContext.Invoice.Where (x => x.Idinvoice == InvoiceAndQty[i].CartInvoiceId &&
                                                                                                x.Date.Value.Month == month &&
                                                                                                 x.FactoryId == factory)
                                                                                                 .Select(x => x.Idinvoice).SingleOrDefaultAsync();
                                    if (one != 0) { invoicesNumbers.Add(one); } else continue;
                                }
                                else
                                {
                                    int one = await _yamamadbContext.Invoice.Where(x => x.Idinvoice == InvoicesID[i] &&
                                                                                            x.Date.Value.Month == month &&
                                                                                             x.ProjectId == project)
                                                                                             .Select(x => x.Idinvoice).SingleOrDefaultAsync();
                                    invoicesNumbers.Add(one);
                                }
                            }

                            for (int j = 0; j < invoicesNumbers.Count; j++)
                            {
                                Invoice subResult = await GetInvoice(invoicesNumbers[j]);
                                value += Convert.ToDouble(subResult.FullCost.Value);

                                for (int a = 0; a < InvoiceAndQty.Count; a++)
                                {
                                    if (invoicesNumbers[j] == InvoiceAndQty[a].CartInvoiceId)
                                    {
                                        Quantity += InvoiceAndQty[a].Qty;
                                    }
                                    else continue;
                                }

                            }
                            MoneyAndQuantity moneyAndQuantity = new MoneyAndQuantity();
                            moneyAndQuantity.Money = value;
                            moneyAndQuantity.Quantity = Quantity;
                            result.Add(moneyAndQuantity);

                           

                        }


                        return result;
                    }
                    if (period == "annual")
                    {
                        //Define list of Double to store the result
                        List<MoneyAndQuantity> result = new List<MoneyAndQuantity>();

                        for (var year = from.Year; year <= end.Year; year++)
                        {
                            //to store the full sales
                            Double value = 0;
                            //to store the full Quantities for each day
                            Double Quantity = 0;

                            //list of id_invoices in each day
                            List<int> invoicesNumbers = new List<int>();

                            //string test = day.ToString("yyyy-MM-dd");

                            for (int i = 0; i < InvoicesID.Count; i++)
                            {

                                if (factory != 0)
                                {

                                    int one = await _yamamadbContext.Invoice.Where(x => x.Idinvoice == InvoiceAndQty[i].CartInvoiceId &&
                                                                                                x.Date.Value.Year ==year &&
                                                                                                 x.FactoryId == factory)
                                                                                                 .Select(x => x.Idinvoice).SingleOrDefaultAsync();
                                    if (one != 0) { invoicesNumbers.Add(one); } else continue;
                                }
                                else
                                {
                                    int one = await _yamamadbContext.Invoice.Where(x => x.Idinvoice == InvoicesID[i] &&
                                                                                            x.Date.Value.Year == year &&
                                                                                             x.ProjectId == project)
                                                                                             .Select(x => x.Idinvoice).SingleOrDefaultAsync();
                                    invoicesNumbers.Add(one);
                                }
                            }


                            for (int j = 0; j < invoicesNumbers.Count; j++)
                            {
                                Invoice subResult = await GetInvoice(invoicesNumbers[j]);
                                value += Convert.ToDouble(subResult.FullCost.Value);

                                for (int a = 0; a < InvoiceAndQty.Count; a++)
                                {
                                    if (invoicesNumbers[j] == InvoiceAndQty[a].CartInvoiceId)
                                    {
                                        Quantity += InvoiceAndQty[a].Qty;
                                    }
                                    else continue;
                                }

                            }
                            MoneyAndQuantity moneyAndQuantity = new MoneyAndQuantity();
                            moneyAndQuantity.Money = value;
                            moneyAndQuantity.Quantity = Quantity;
                            result.Add(moneyAndQuantity);

                        }


                        return result;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return null;
        }

      
    }
    }


