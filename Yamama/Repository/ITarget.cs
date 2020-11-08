using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Yamama.Models;

namespace Yamama.Repository
{
    public interface ITarget
    {
        Task<int> AddTarget(Target target);
        Task<int> UpdateTarget(int id,Target target);
        Task<int> DeleteTarget(int id);
        List<Double> EvaluateSalesman(int salesman, string period, DateTime start, DateTime end);
       //Task<List<Double>> GetVisitTartget(int salesman, string period, DateTime start, DateTime end);

    }
}
