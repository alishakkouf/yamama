using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
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
    public class ProductionService : IProduction
    {
        //inject the dbcontext
        private readonly yamamadbContext _db;
          
        // create a new instance from the  injected dbcontext 
        public ProductionService(yamamadbContext db )
        {
            _db = db;         
        }

        // add a new production 
        // we use the (StoreViewModel) view model because we will need data from  more than one table 
        public async Task <int> AddProductionAsync( StoreViewModel model)
        {
            // declare a variable
            int result = 0;

            // check if the model has a value  
            if (model.production != null)
            {
                //if the model has values then create a new object from Production model
                Production prod = new Production
                {
                    IdProduct = model.production.IdProduct,
                    Quantity = model.production.Quantity,
                    Date = model.production.Date,
                };
                // add the new production object to database
                await _db.Production.AddAsync(prod);
                //commit the changes into database
                await _db.SaveChangesAsync();
                //get the added production and store it in variable
                var RecentProduction = _db.Production.OrderByDescending(p => p.Idproduction ).FirstOrDefault();
                 // get the product id from this added  production from the RecentProduction variable
                int? id = RecentProduction.IdProduct.Value;

                //get the quantity from the added production  from the RecentProduction variable
                int qty = RecentProduction.Quantity.Value;

                 // creat a loop to pass the store records and update the product quantity according to the product id 
                foreach (var item in _db.Store)
                {
                    if (item.ProductId==id)
                    {
                        item.Quantity += qty;
                    }
                }
                //commit the changes into database
                _db.SaveChanges();
                //if the operation succecced return 1
                result += 1;
                
            };
           
            return result;
        }


        // get specific production based on the production  id 
        public async Task<Production> GetProduction(int id)
        {

            return await _db.Production.FirstOrDefaultAsync(f => f.Idproduction == id);
        }


        //// delete an existing production based on the production id
        //public async Task<int> DeleteProductionAsync(int id)
        //{
        //    int result = 0;
        //    //check if the dbcontext is not null
        //    if (_db != null)
        //    {
        //        // if not  then find the specified production
        //        var production = await _db.Production.FirstOrDefaultAsync(p => p.Idproduction == id);

        //        //check if the returned value is not null
        //        if (production != null)

        //        // if it not null delete the specific production
        //         _db.Production.Remove(production);

        //        //commit the changes on database
        //        await _db.SaveChangesAsync();
        //        //if the operation succecced return 1
        //        result += 1;
        //        return result;
        //    }
        //    return result;
        //}

        /////get all production
        //public async Task<List<Production>> GetAllProduction()
        //{
        //    //check if the dbcontext is not null
        //    if (_db != null)
        //    {
        //        // if not find all productions
        //        return await _db.Production.ToListAsync();
        //    }
        //    return null;
        //}
       
        ////update specific production
        //public async Task<int> UpdateProduction(int id, Production production)
        //{
        //    int result = 0;
        //    //check if the dbcontext is not null
        //    if (_db != null)
        //    {
        //        //if not create a new object from  specific production 
        //        Production existproduction = await _db.Production.Where(f => f.Idproduction == id).FirstOrDefaultAsync();
        //        //check the returned object  is not null
        //        if (existproduction != null)
        //        {
        //            existproduction.ProductId = production.ProductId;
        //            existproduction.Quantity = production.Quantity;
        //            existproduction.Date = production.Date;
        //        }
        //        //edit the returned object 
        //        _db.Production.Update(existproduction);
        //        //commit changes
        //        await _db.SaveChangesAsync();
        //        result += 1;
        //        return result;
        //    }
        //    return result;
        //}
    


        /// Reports for production (daily - monthly - annual)
        public async  Task<List<double>> GetProductinReports(string period, DateTime from, DateTime to)
        {
            try
            {
                if (period == "daily")
                {
                    //Define list of production to store the result  
                    List<Double> result = new List<double>();
                    //System.TimeSpan diff = to.Subtract(from);

                    for (var day = from.Date; day <= to; day.AddDays(1))
                    {                   
                    //to store the total production
                    Double value = 0;
                    // a format to deal with the date 
                    string dateday = day.ToString("yyyy-MM-dd");
                    //return list of id_production in each day
                    List<int> productionNumber = _db.Production.Where(p => p.Date.ToString() == dateday).Select(p => p.Idproduction).ToList();
                    for (int j = 0; j < productionNumber.Count; j++)
                    {
                        Production subresult = await GetProduction(productionNumber[j]);
                        value += Convert.ToDouble(subresult.Quantity.Value);
                    }
                    result.Add(value);
                    }
                    return result;
                }
                else if (period == "monthly")
                {
                    //Define list of production to store the result  
                    List<Double> result = new List<double>();
                    System.TimeSpan diff = to.Subtract(from);
                    for (var month = from.Month; month <= to.Month; month++)
                    {
                        //to store the total production
                        Double value = 0;
                        //return list of id_production in each day
                        List<int> productionNumber = _db.Production.Where(p => p.Date.Value.Month == month).Select(p => p.Idproduction).ToList();

                        for (int j = 0; j < productionNumber.Count; j++)
                        {
                            Production subresult = await GetProduction(productionNumber[j]);
                            value += Convert.ToDouble(subresult.Quantity.Value);
                        }
                        result.Add(value);
                    }
                    return result;
                }
                else if (period=="annual")
                {

                    //Define list of production to store the result  
                    List<Double> result = new List<double>();

                    System.TimeSpan diff = to.Subtract(from);

                    for (var year = from.Year; year <= to.Year; year++)
                    {
                        //to store the total production
                        Double value = 0;

                        //return list of id_production in each day
                        List<int> productionNumber = _db.Production.Where(x => x.Date.Value.Year == year).Select(x => x.Idproduction).ToList();

                        for (int j = 0; j < productionNumber.Count; j++)
                        {
                            Production subResult = await GetProduction(productionNumber[j]);
                            value += Convert.ToDouble(subResult.Quantity.Value);
                        }
                        result.Add(value);
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
