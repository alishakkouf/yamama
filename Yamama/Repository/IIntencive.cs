using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Yamama.Models;

namespace Yamama.Repository

{
    public interface IIntencive
    {
        Task<int> AddActualIntencive(ActualIntencive actual);
        Task<int> AddExpectedIntencive(ExpectedIntencive expected);
        Task<int> UpdateActualIntencive(int id, ActualIntencive actual);
        Task<int> UpdateExpectedIntencive(int id, ExpectedIntencive expected);
        Task<int> DeleteActualIntencive(int id);
        Task<int> DeleteExpectedIntencive(int id);
        Task<List<(string, double)>> GetExpectedIntenciveByUser(int user, string period, DateTime start, DateTime end);
        Task<List<(string, double)>> GetActualIntenciveByUser(int user, string period, DateTime start, DateTime end);
        Task<ExpectedIntencive> GetDailyExpectedIntencive(int id);
        Task<ActualIntencive> GetDailyActualIntencive(int id);
        //Task<List<Double>> GetExpectedIntenciveAll(string period, DateTime start, DateTime end);
        //Task<List<Double>> GetActualIntenciveAll(string period, DateTime start, DateTime end);
    }
}
