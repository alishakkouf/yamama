using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yamama.ViewModels;

namespace Yamama.Repository
{
    public interface IStore
    {
        
        Task<int> AddstoreAsync(Store store);

        ///***** reporting for stores based on product type ...................

        List<(string,Double)> GetProductStore(string  name);
        Task <Double> GetTotalStore();

    }
}
