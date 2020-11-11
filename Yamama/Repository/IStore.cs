using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Yamama.Repository
{
    public interface IStore
    {
        
        Task<int> AddstoreAsync(Store store);
     
       ///***** reporting for stores based on product type ...................

          int GetProductStore(int id);
          Task <int> GetTotalStore();

    }
}
