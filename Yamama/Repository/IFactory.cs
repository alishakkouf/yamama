using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yamama.Models;

namespace Yamama.Repository
{
    public  interface IFactory
    {
        
        Task <List<Factory>> GetFactories();
        Task <Factory> GetFactory(int id);
        Task <int> AddFactoryAsync(Factory factory);

        Task <int> UpdateFactory(int id, Factory factory);

        Task<int> DeleteFactoryAsync(int id);
    }
}
