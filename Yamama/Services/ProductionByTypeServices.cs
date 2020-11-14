using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Yamama.Models;
using Yamama.Repository;
using Microsoft.EntityFrameworkCore;

namespace Yamama.Services
{
    public class ProductionByTypeServices : IProductionByType
    {
        private readonly yamamadbContext _db;
        
        public ProductionByTypeServices(yamamadbContext db)
        {
            _db = db;
        }
        public async Task<int> AddProduction(Production prod)
        {
            if (_db != null)
            {

                await _db.Production.AddAsync(prod);
                await _db.SaveChangesAsync();
                return 1;
            }
            return 0;
        }

        public async Task<int> DeleteProd(int id)
        {
            if (_db != null)
            {
                var item = _db.Production.FirstOrDefault(p => p.Idproduction == id);
                if (item != null)
                {
                    _db.Production.Remove(item);
                    await _db.SaveChangesAsync();
                    return 1;
                }
            }
            return 0;
        }

        public async Task<List<Production>> GetAllDailyProd(string type)
        {
            if (_db != null)
            {
                var productId = _db.Product.Where(x => x.Name == type).Select(x => x.Idproduct).SingleOrDefault();
                var item = await _db.Production.Where(x => x.IdProduct == productId).ToListAsync();
                return item;
            }
            return null;
        }
        
        public async Task<Production> GetDailyProd(int id)
        {
            var item = await _db.Production.FirstOrDefaultAsync(v => v.Idproduction == id);
            return item;
        }

        public async Task<List<double>> GetProductionReports(string type,string period, DateTime start, DateTime end)
        {
            try
            {
                if (period == "daily")
                {
                    //Define list of production each day to store the result
                    List<Double> result = new List<double>();
                    var productId = _db.Product.Where(x => x.Name == type).Select(x => x.Idproduct).SingleOrDefault();
                    
                    for (var day = start.Date; day <= end.Date; day = day.AddDays(1))
                    {
                        //to store the full productions
                        
                        Double value = 0;

                        string test = day.ToString("yyyy-MM-dd");
                        //return list of Idproduction in each day
                        List<int> productions = _db.Production.Where(x => x.Date.ToString() == test && x.IdProduct == productId)
                                                                     .Select(x => x.Idproduction).ToList();



                        for (int j = 0; j < productions.Count; j++)
                        {
                            Production subResult = await GetDailyProd(productions[j]);
                            value += Convert.ToDouble(subResult.Quantity.Value);
                        }
                        result.Add(value);
                        
                    }
                    return result;
                }
                else if (period == "monthly")
                {
                    //Define list of productions to store the result
                    List<Double> result = new List<double>();
                    var productId = _db.Product.Where(x => x.Name == type).Select(x => x.Idproduct).SingleOrDefault();
                    for (var month = start.Month; month <= end.Month; month++)
                    {
                        //to store the full sales
                        Double value = 0;

                        //return list of idproduction in each day
                        List<int> productions = await _db.Production.Where(x => x.Date.Value.Month == month && x.IdProduct == productId)
                        .Select(x => x.Idproduction).ToListAsync();
                        for (int j = 0; j < productions.Count; j++)
                        {
                            Production subResult = await GetDailyProd(productions[j]);
                            value += Convert.ToDouble(subResult.Quantity.Value);

                        }
                        result.Add(value);
                    }


                    return result;
                }
                else if (period == "annual")
                {
                    //Define list of invoices to store the result
                    List<Double> result = new List<double>();
                    var productId = _db.Product.Where(x => x.Name == type).Select(x => x.Idproduct).SingleOrDefault();
                    for (var year = start.Year; year <= end.Year; year++)
                    {
                        //to store the full sales
                        Double value = 0;

                        //return list of id_invoices in each day
                        List<int> productions = await _db.Production.Where(x => x.Date.Value.Year == year && x.IdProduct == productId)
                        .Select(x => x.Idproduction).ToListAsync();
                        for (int j = 0; j < productions.Count; j++)
                        {
                            Production subResult = await GetDailyProd(productions[j]);
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

        public async Task<int> UpdateProd(int id, Production prod)
        {
            if (_db != null)
            {
                Production existItem = _db.Production
                .Where(f => f.Idproduction == id).FirstOrDefault();
                if (existItem != null)
                {
                    existItem.IdProduct = prod.IdProduct;
                    existItem.Quantity = prod.Quantity;
                    existItem.Date = prod.Date;
                    

                    _db.Production.Update(existItem);
                    await _db.SaveChangesAsync();
                    return 1;
                }
            }
            return 0;
        }
    }
}
