using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Yamama.Models;

namespace Yamama.Repository
{
   public  interface IProduct
    {
        //to get the price for specific product(this function will be called in the balance service)
        Task<decimal> GetProductPrice(int id);

        //to get specific product details(this function will be called in the balance service)
        Task<Product> GetProduct(int id);
    }
}
