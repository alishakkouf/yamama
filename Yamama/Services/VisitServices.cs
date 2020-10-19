using System;
using System.Collections.Generic;
using System.Linq;
using Yamama.Repository;
using Yamama.Models;

namespace Yamama.Services
{
    public class VisitServices : IVisit
    {
        private readonly yamamaContext _db;

        public VisitServices(yamamaContext db)
        {
            _db = db;
        }

        //Adding new Visit
        public void AddVisit(Visit visit)
        {
            _db.Visit.Add(visit);
        }

        //select all visits whith status is Done (Assume TaskStatus:1=ToDo, 2=Doing, 3=Done, 4=New)
        //the status from Task
        public List<Visit> ArchiveVisit()
        {
            if (_db != null)
            {
                //var item = from visit in Visit join task in  on visit.Idvisit equals task.Idtask where task.StatusId = 3 select visit;

                var item = (from visit in _db.Visit
                           join task in _db.Task on visit.Idvisit equals task.Idtask
                           where task.StatusId == 3
                           select visit).ToList();

                return item; 


            }
            return null;
        }

        //Getting list of All Visits of all status
        public List<Visit> GetAllVisits()
        {
            if (_db != null)
            {
                return _db.Visit.ToList();
            }
            return null;
        }

        //select all visits whith status is New (Assume TaskStatus:1=ToDo, 2=Doing, 3=Done, 4=New)
        //the status from Task
        public List<Visit> NewAssignedVisits()
        {

            if (_db != null)
            {
                
                var item = (from visit in _db.Visit
                           join task in _db.Task on visit.Idvisit equals task.Idtask
                           where task.StatusId == 4
                           select visit).ToList();

                
                return item;
            }
            return null;
        }


        //Generating Report for a specific Visit by it's id
        public Visit VisitReport(int id)
        {
            
            var item = _db.Visit.FirstOrDefault( v => v.Idvisit == id);
            return item;
            
        }

    }
}
        