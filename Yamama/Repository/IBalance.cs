using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Yamama.Repository
{
   public  interface IBalance
    {
        // function to move the quantity of product from store to balance 
        Task<int> AddBalanceAsync(int id);

        // get product balance by quantity
        Task<List<double>> GetProductBalanceQty( DateTime date, int id);

        // get product balance by price
        Task<List<double>> GetProductBalancePrice(DateTime date, int id);

        // get  balance for all  by quantity

        Task<List<double>> GetBalanceQty(DateTime date);

        //get list of  balance for all product by price 

        Task<List<(int,double)>> GetBalancePrice(DateTime date);


        //get the total balance for all product


        Task< double> GetAllBalancePrice(DateTime date);






    }
}
