using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Yamama.Models;
using Yamama.Repository;

namespace Yamama.Services
{
    public class ProductService : IProduct
    {

        private readonly yamamadbContext _db;
        public ProductService(yamamadbContext db)
        {
            _db = db;
        }
        // get product details
        public async Task<Product> GetProduct(string name)
        {
            int prodid = _db.Product.Where(x => x.Name == name).Select(x => x.Idproduct).FirstOrDefault();
            if (_db != null)
            {
                var product = await _db.Product.FirstOrDefaultAsync(f => f.Idproduct == prodid);
                return product;
            }
            return null;
        }

        ///to get the price of specific product
        public async Task<Double> GetProductPrice(string name)
        {
            int prodid = _db.Product.Where(x => x.Name == name).Select(x => x.Idproduct).FirstOrDefault();
            Double result = 0;
            try
            {
                
                result = await _db.Product.Where(p => p.Idproduct == prodid).Select(p => p.Price).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception)
            {

                return result;
            }
           
        }

    
    }
}
