using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yamama.Models;

namespace Yamama.Repository
{
    public interface IVisit
    {
        void AddVisit(Visit visit);
        Visit VisitReport(int id);
        List<Visit> GetAllVisits();
        List<Visit> NewAssignedVisits();
        List<Visit> ArchiveVisit();
    }
}
