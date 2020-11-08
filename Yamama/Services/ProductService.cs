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
        public async Task<Product> GetProduct(int id)
        {
            var product = await _db.Product.FirstOrDefaultAsync(f => f.Idproduct == id);
            return product;
        }

        ///to get the price of specific product
        public async Task<Decimal> GetProductPrice(int id)
        {
            return await _db.Product.Where(p => p.Idproduct == id).Select(p=>p.Price).FirstOrDefaultAsync();
        }

    
    }
}
