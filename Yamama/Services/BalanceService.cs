using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Yamama.Models;
using Yamama.Repository;

namespace Yamama.Services
{
    public class BalanceService : IBalance
    {

        private readonly yamamadbContext _db;

        private readonly IProduct _product;

        private readonly IStore _store;
        public BalanceService(yamamadbContext db, IProduct product, IStore store/*, /*I_ImportInvoce import*/)
        {
            _db = db;
            _product = product;
            _store = store;
        }
      /*  this finction will recieve product id as parameter and get the current quantity for this product in
        the store and  create a new object from balance class and fill the last period and first period with
        this quantity and  let the date of last period as the current date
       and the date of first is the first day of the next month and the product id is the passed parameter*/
        public async Task<int> AddBalanceAsync(int id)
        {

                //get quantity of this product in store
                int qty = _store.GetProductStore(id);
                //get the current date
                var dateandtime = DateTime.Now;
                var date = dateandtime.Date;
                //create a new object from balance class
                Balance newbalance = new Balance
                {
                    ProductId = id,
                    FirstPeriod = qty,
                    LastPeriod = qty,
                    DateOfFirst = date.AddMonths(1).AddDays(-date.Day + 1),
                    DateOfLast = date,
                };
                //add the balance record to database
                await _db.Balance.AddAsync(newbalance);
                //save changes
                await _db.SaveChangesAsync();
                return qty;                    
           
        }

        // report last period quantity for all products we need here to enter the date of last period 
        public async Task <List<double>> GetBalanceQty(DateTime date)
        {
            try
            {
                //Define list of products to store the result
                List<Double> result = new List<double>();
                var value = await _db.Balance.Where(b => b.DateOfLast == date).SumAsync(b => b.LastPeriod);

                result.Add(value);

                return result;
            }

            catch (Exception)
            {
                return null;
            }
        }

        //report last period value(ton) for all products  we need here to enter the date of last period  
        public async Task<List<(int,double)>> GetBalancePrice(DateTime date)
        {
            try
            {               
                // pass all balance record
                foreach (var item in _db.Balance)
                {
                    //Define list of products to store the result
                    List<(int,Double)> result = new List<(int,double)>();                 
                    //to store the  products that added in this date
                    List<int> productNumber = _db.Balance.Where(p => p.DateOfLast == date).Select(x => x.ProductId).ToList();
                    for (int i = 0; i < productNumber.Count; i++)
                    {
                        //variable to store the total last period  value (qty * price for each product in this month)
                        double value = 0;
                        int id = productNumber[i];
                        //get the value of last period for each product 
                        int qty = _db.Balance.Where(b => b.ProductId == productNumber[i]).Select(b => b.LastPeriod).FirstOrDefault();
                        //get the price for each product
                        decimal val = await _product.GetProductPrice(productNumber[i]);

                        value += Convert.ToDouble(val) * qty;
                        result.Add((id, value));
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
        //report last period  by value(ton) based on  product id and the date of last period 
        public async Task<List<double>> GetProductBalancePrice(DateTime date, int id)
        {
            try
            {
                //Define list of products to store the result
                List<Double> result = new List<double>();
                double ton = 0;
                // get the price of the product
                decimal value = await _product.GetProductPrice(id);
                // get the last period of the product
                var qty = await _db.Balance.Where(b => b.ProductId == id && b.DateOfLast == date).Select(b => b.LastPeriod).FirstOrDefaultAsync();
                ton = Convert.ToDouble(value) * Convert.ToDouble(qty);
                result.Add(ton);

                return result;
            }
            catch(Exception)
            {
                return null;
            }
        }

        // report last period quantity based on  product id and the date of last period 
        public async Task<List<double>> GetProductBalanceQty(DateTime date, int id)
        {
            try
            {
                //Define list of products to store the result
                List<Double> result = new List<double>();
                //get the last period value based on specific product
                var value = await _db.Balance.Where(b => b.ProductId == id && b.DateOfLast == date).Select(b => b.LastPeriod).FirstOrDefaultAsync();

                result.Add (value);
                return result;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public async Task<double> GetAllBalancePrice(DateTime date)
        {
            try
            {
                // pass all balance record
                foreach (var item in _db.Balance)
            {
               
                //variable to store the total last period  value (qty * price for each product in this month)
                double ton = 0;
                //to store the  products that added in this date
                List<int> productNumber = _db.Balance.Where(p => p.DateOfLast == date).Select(x => x.ProductId).ToList();
                for (int i = 0; i < productNumber.Count; i++)
                {
                    //get the value of last period for each product 
                    int qty = _db.Balance.Where(b => b.ProductId == productNumber[i]).Select(b => b.LastPeriod).FirstOrDefault();
                    //get the price for each product
                    decimal val = await _product.GetProductPrice(productNumber[i]);

                    ton += Convert.ToDouble(val) * qty;
                   
                }
                    return ton;     
            }
            return 0;

            }

            catch (Exception)
            {
                return 0;
            }
        }
    }   
}
