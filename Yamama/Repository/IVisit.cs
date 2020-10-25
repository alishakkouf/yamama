using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yamama.Models;
using Yamama.ViewModels;

namespace Yamama.Repository
{
    public interface IVisit
    {
        Task<int> AddVisit(TaskTypeViewModel taskTypeViewModel);
        Task<Visit> VisitReport(int id);
        Task<List<Visit>> GetAllVisits();
        Task<List<Visit>> NewAssignedVisits();
        Task<List<Visit>> ArchiveVisit();
        Task<int> UpdateVisit(int id, TaskTypeViewModel taskTypeViewModel);
        Task<int> DeleteVisit(int id);
    }
}
