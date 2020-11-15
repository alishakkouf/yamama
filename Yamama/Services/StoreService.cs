using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Yamama.Models;
using Yamama.Repository;
using Yamama.ViewModels;

namespace Yamama.Services
{
    public class StoreService : IStore
    {

        private readonly yamamadbContext _db;     
        public StoreService(yamamadbContext db )
        {
            _db = db;         
        }

        // we need to aggregate the previous quantity + the production quantity + imported quantity - (sales+export)
        public async Task<int> AddstoreAsync(Store store)
        {
            int result = 0;
            // add new store
            //await _db.Store.AddAsync(store);
            //if the operation succecced return 1
            result += 1;
            return result;

        }

        /////*****reporting *****

        //get the existing quantity in store for specific product
        public   List<(string, int)> GetProductStore(string name)
        {
 
                 int prodid = _db.Product.Where(x => x.Name == name).Select(x => x.Idproduct).FirstOrDefault();
                List<(string, int)> result = new List<(string, int)>();
                int qty = _db.Store.Where(s => s.ProductId == prodid).Select(s => s.Quantity).FirstOrDefault();
                //string nam = _db.Product.Where(p => p.Idproduct ==id).Select(p => p.Name).FirstOrDefault();
                result.Add((name, qty));
            
                return result; 
        }
        //get the existing quantity in store for specific product
        public async Task<int> GetTotalStore()
        {
            int qty = +await _db.Store.SumAsync(s => s.Quantity);

            return qty;
          
        }



        public async Task<Store> GetStore(int id)
        {
            //get all stores
            return await _db.Store.FirstOrDefaultAsync(f => f.Idstore == id);
        }
        public async Task<List<Store>> GetStores()
        {
            //check if the model is not null
            if (_db != null)
            {
                // if not find all stores
                return await _db.Store.ToListAsync();
            }
            return null;
        }

    }
}
