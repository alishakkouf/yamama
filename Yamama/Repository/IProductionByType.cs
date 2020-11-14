using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Yamama.Models;

namespace Yamama.Repository
{
    public interface IProductionByType
    {
        Task<int> AddProduction(Production prod);
        Task<int> UpdateProd(int id,  Production prod);
        Task<int> DeleteProd(int id);
        Task<List<Production>> GetAllDailyProd(string type);
        Task<Production> GetDailyProd(int id);
        Task<List<Double>> GetProductionReports(string type, string period, DateTime start, DateTime end);
    }
}
