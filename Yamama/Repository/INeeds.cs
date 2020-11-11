using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Yamama.Repository
{
    public interface INeeds
    {
        Task<int> AddActualNeeds(ActualNeeds actual);
        Task<int> AddExpectedNeeds(ExpectedNeeds expected);
        Task<int> UpdateActualNeeds(int id, ActualNeeds actual);
        Task<int> UpdateExpectedNeeds(int id, ExpectedNeeds expected);
        Task<int> DeleteActualNeeds(int id);
        Task<int> DeleteExpectedNeeds(int id);
        Task<List<Double>> GetExpectedNeedsByType(int type, string period, DateTime start, DateTime end);
        Task<List<Double>> GetActualNeedsByType(int type, string period, DateTime start, DateTime end);
        Task<ExpectedNeeds> GetDailyExpectedNeeds(int id);
        Task<ActualNeeds> GetDailyActualNeeds(int id);


    }
}
