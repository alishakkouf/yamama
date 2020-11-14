using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Yamama.Models;
using Yamama.ViewModels;


namespace Yamama.Repository
{
    public interface IProduction
    {
        //add new production during a day
        Task<int> AddProductionAsync(Production prouction);

        //gedt production according to the production_id
        Task<Production> GetProduction(int id);

        // Reports of  the production for all products (daily- monthly- annual)
        Task<List<double>> GetProductinReports(string period , DateTime from, DateTime to);



        

    }
}
