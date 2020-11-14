﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
//using Yamama.Models;
using Yamama.Repository;
using Yamama.ViewModels;

namespace Yamama.Services
{
    public class ImportInvoiceService : I_ImportInvoce
    {
        private readonly yamamadbContext _db;
        private readonly ICart _cart;
        private readonly IInvoicecs _invoice;
        public ImportInvoiceService(yamamadbContext db, ICart cart, IInvoicecs invoice)
        {
            _db = db;
            _cart = cart;
            _invoice = invoice;
        }
        // add new  import invoice (this operation will affect on store quantity where the quantity in the store for specific product will increase with every added invoice)
        public async Task<Invoice> AddImportInvoceAsync(InvoiceCartViewModel impoInvoice)
        {
            try
            {
                if (impoInvoice.invoice.Paid < impoInvoice.invoice.FullCost)
                {
                    impoInvoice.invoice.RemainForYamama = impoInvoice.invoice.FullCost - impoInvoice.invoice.Paid;
                }
               else if (impoInvoice.invoice.Paid > impoInvoice.invoice.FullCost)
                {
                    impoInvoice.invoice.RemainForCustomer = impoInvoice.invoice.Paid - impoInvoice.invoice.FullCost;
                }
              else  
                {
                    impoInvoice.invoice.RemainForCustomer = impoInvoice.invoice.RemainForYamama = 0;
                } 
                
                // if one of the previous conditions is true then save the invoice in the database
                await _db.Invoice.AddAsync(impoInvoice.invoice);
                //commit the changes
                await _db.SaveChangesAsync();

                //get id for this invoice

                var RecentInvoice = _db.Invoice.OrderByDescending(p => p.Idinvoice).FirstOrDefault();
              
                int RecentInvoiceID = RecentInvoice.Idinvoice;           
                //add cart for this invoice
                await _cart.AddCartAsync(impoInvoice, RecentInvoiceID);
                _db.SaveChanges();
                //get the last addes cart
                var RecentCart = _db.Cart.OrderByDescending(c => c.IdCart).FirstOrDefault();
                //get the quantity from this cart
                int qty = RecentCart.Qty;
                //get the product id from this cart
                int? id = RecentCart.ProductId;

                //pass the store records and add the quantity for the specific product id
                foreach (var item in _db.Store)
                {
                    if (item.ProductId == id)
                    {
                        item.Quantity += qty;
                    }
                }
                //commit changes
                _db.SaveChanges();
               
                return impoInvoice.invoice;
            }
            catch
            {
                return null;
            }
        }
        ///...............Report for Import for all products................
        ///
        public async Task<List<double>> GetImportedReports(string period, DateTime from, DateTime to, string invoType)
        {
            try
            {
                if (period=="daily")
                {
                     //Define list of invoices to store the result
                    List<Double> result = new List<double>();
                    System.TimeSpan diff = to.Subtract(from);
                    for (var day = from.Date; day <= to; day.AddDays(1))
                    {
                      //to store the full imports 
                      Double value = 0;
                    string dateday = day.ToString("yyyy-MM-dd");
                     //return list of id_invoices in each day
                    List<int> importNumber = _db.Invoice.Where(p => p.Date.ToString() == dateday && p.Type == invoType).Select(p => p.Idinvoice).ToList();
                    
                    for (int j = 0; j < importNumber.Count; j++)
                    {
                        Invoice subresult = await _invoice.GetInvoice(importNumber[j]);
                        value += Convert.ToDouble(subresult.FullCost);
                    }
                    result.Add(value);
                    }
                    return result;
                }


                else if (period=="monthly")
                {
                    //Define list of invoices to store the result
                    List<Double> result = new List<double>();
                    System.TimeSpan diff = to.Subtract(from);
                    for (var month = from.Month; month <= to.Month; month++)
                    {
                        //to store the full imports
                        Double value = 0;
                        //return list of id_invoices in each day
                        List<int> importNumber = _db.Invoice.Where(p => p.Date.Value.Month == month && p.Type == invoType).Select(p => p.Idinvoice).ToList();
                        for (int j = 0; j < importNumber.Count; j++)
                        {
                            Invoice subresult = await _invoice.GetInvoice(importNumber[j]);
                            value += Convert.ToDouble(subresult.FullCost);
                        }
                        result.Add(value);
                    }
                    return result;
                }

                else if (period =="annual")
                {
                   //Define list of invoices to store the result
                    List<Double> result = new List<double>();
                    System.TimeSpan diff = to.Subtract(from);
                    for (var year = from.Year; year <= to.Year; year++)
                    {
                        //to store the full imports
                        Double value = 0;
                        //return list of id_invoices in each day
                        List<int> importNumber = _db.Invoice.Where(x => x.Date.Value.Year == year && x.Type == invoType).Select(x => x.Idinvoice).ToList();
                        for (int j = 0; j < importNumber.Count; j++)
                        {
                            Invoice subResult = await _invoice.GetInvoice(importNumber[j]);
                            value += Convert.ToDouble(subResult.FullCost);
                        }
                        result.Add(value);
                    }
                    return result;
                }

                return null;

            }

            catch(Exception)
            {
                return null;
            }
        }

        ///..........Reports for import based on type product..............
        

        public async  Task<List<(string, double)>> GetProductImportedReports(string period, DateTime from, DateTime to, string  name, string invoType)
        {

            //get the id for the entered product name
            int prodid = _db.Product.Where(x => x.Name == name).Select(x => x.Idproduct).FirstOrDefault();
            try
            {
                if (period == "daily")
                {
                    //Define list of invoices to store the result
                    List<(string, Double)> result = new List<(string, double)>();
              
                    System.TimeSpan diff = to.Subtract(from);
                    for (var day = from.Date; day <= to; day.AddDays(1))
                    {
                        //to store the full imports
                        Double value = 0;
                        string dateday = day.ToString("yyyy-MM-dd");
                        //return list of id_invoices in each daybased on product id
                        List<int> importNumber = await(from import in _db.Invoice
                                                       from cart in _db.Cart
                                                       where import.Idinvoice == cart.InvoiceId
                                                       && import.Date.ToString() == dateday && cart.ProductId == prodid && import.Type==invoType
                                                       select import.Idinvoice).ToListAsync();


                        for (int j = 0; j < importNumber.Count; j++)
                        {
                            Invoice subresult = await _invoice.GetInvoice(importNumber[j]);
                            value += Convert.ToDouble(subresult.FullCost);
                        }
                        result.Add((name,value));
                    }
                    return result;
                }

                else if (period == "monthly")
                {
                    
                    //Define list of invoices to store the result
                    List<(string, Double)> result = new List<(string, double)>();
                  
                    System.TimeSpan diff = to.Subtract(from);
                    for (var month = from.Month; month <= to.Month; month++)
                    {
                        //to store the full imports
                        Double value = 0;
                        //return list of id_invoices in each daybased on product id
                        List<int> importNumber = await(from import in _db.Invoice
                                                       from cart in _db.Cart
                                                       where import.Idinvoice == cart.InvoiceId
                                                       && import.Date.Value.Month == month && cart.ProductId == prodid && import.Type == invoType
                                                       select import.Idinvoice).ToListAsync();
                        for (int j = 0; j < importNumber.Count; j++)
                        {
                            Invoice subresult = await _invoice.GetInvoice(importNumber[j]);
                            value += Convert.ToDouble(subresult.FullCost);
                        }
                        result.Add((name,value));
                    }
                    return result;
                }

                else if (period == "annual")
                {
                    List<(string, Double)> result = new List<(string, double)>();                
                    System.TimeSpan diff = to.Subtract(from);
                    for (var year = from.Year; year <= to.Year; year++)
                    {
                        //to store the full sales
                        Double value = 0;
                        //return list of id_invoices in each daybased on product id

                        List<int> importNumber = await(from import in _db.Invoice
                                                       from cart in _db.Cart
                                                       where import.Idinvoice == cart.InvoiceId
                                                       && import.Date.Value.Year == year && cart.ProductId == prodid && import.Type == invoType
                                                       select import.Idinvoice).ToListAsync();
                     
                        for (int j = 0; j < importNumber.Count; j++)
                        {
                            Invoice subResult = await _invoice.GetInvoice(importNumber[j]);
                            value += Convert.ToDouble(subResult.FullCost);
                        }
                        result.Add((name, value));
                    }
                    return result;
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
