using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Yamama.Models;
using Yamama.ViewModels;

namespace Yamama.Repository
{
    public interface IVisit
    {
        Task<int> AddVisit(TaskTypeViewModel taskTypeViewModel);
        Task<Visit> GetVisitbyID(int id);
        Task<List<(string, string, double)>> GetVisitReports(string salesman, string projectName, string factoryName, string period, DateTime start, DateTime end);
        Task<List<(string, double)>> GetVisisBySalesman(string salesman, string period, DateTime start, DateTime end);
        Task<List<(string, double)>> GetVisitsByClient(string projectName, string factoryName, string period, DateTime start, DateTime end);
        Task<List<Visit>> GetAllVisits();
        Task<List<Visit>> NewAssignedVisits();
        Task<List<Visit>> ArchiveVisit();
        Task<int> UpdateVisit(int id, TaskTypeViewModel taskTypeViewModel);
        Task<int> DeleteVisit(int id);
        
    }
}
