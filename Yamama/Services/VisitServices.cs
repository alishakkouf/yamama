using System;
using System.Collections.Generic;
using System.Linq;
using Yamama.Repository;
using Yamama.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Yamama.ViewModels;

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
        public async Task<int> AddVisit(TaskTypeViewModel taskTypeViewModel)
        {
            
            if (_db != null)
            {
                
                await _db.Visit.AddAsync(taskTypeViewModel.visit);
                await _db.SaveChangesAsync();
                return 1;
            }
            return 0;
        }

        //select all visits whith status is Done (Assume TaskStatus:1=ToDo, 2=Doing, 3=Done, 4=New)
        //the status from Task where the type is Visit (Assume TaskType:1=Visit, 2=Alert, 3=ASk for information)
        public async Task<List<Visit>> ArchiveVisit()
        {
            if (_db != null)
            {
                

                var item =await (from visit in _db.Visit
                           join task in _db.Task on visit.Idvisit equals task.Idtask
                           where task.StatusId == 3 & task.TypeId == 1
                           select visit).ToListAsync();
               

                return  item; 


            }
            return null;
        }

        //Getting list of All Visits of all status
       // public List<Visit> GetAllVisits()
          public async Task<List<Visit>> GetAllVisits()
        {
            if (_db != null)
            {
                var item = await _db.Visit.ToListAsync();
                return item;
            }
            return null;
        }

        //select all visits whith status is New (Assume TaskStatus:1=ToDo, 2=Doing, 3=Done, 4=New)
        //the status from Task where the type is Visit (Assume TaskType:1=Visit, 2=Alert, 3=ASk for information)
        public async Task<List<Visit>> NewAssignedVisits()
        {

            if (_db != null)
            {
                
                var item = await (from visit in _db.Visit
                           join task in _db.Task on visit.Idvisit equals task.Idtask
                           where task.StatusId == 4 & task.TypeId == 1
                           select visit).ToListAsync();

                
                return item;
            }
            return null;
        }


        //Generating Report for a specific Visit by it's id
        public async Task<Visit> VisitReport(int id)
        {
            var item = await _db.Visit.FirstOrDefaultAsync( v => v.Idvisit == id);
            return item;
            
        }

        public async Task<int> UpdateVisit(int id, TaskTypeViewModel taskTypeViewModel)
        {
            if (_db != null)
            {
                Visit existItem =  _db.Visit.Where(f => f.Idvisit == id).FirstOrDefault();
                if (existItem != null)
                {
                    existItem.UserId = taskTypeViewModel.visit.UserId;
                    existItem.FactoryId = taskTypeViewModel.visit.FactoryId;
                    existItem.ProjectId = taskTypeViewModel.visit.ProjectId;
                    existItem.TaskId = taskTypeViewModel.visit.TaskId;
                    
                }

                _db.Visit.Update(existItem);
                await _db.SaveChangesAsync();
                return 1;

            }
            return 0;
        }


        public async Task<int> DeleteVisit(int id)
        {
            if (_db != null)
            {
                var item = _db.Visit.FirstOrDefault(p => p.Idvisit == id);

                if (item != null)
                {
                    _db.Visit.Remove(item);
                    await _db.SaveChangesAsync();
                    return 1;
                }
            }
            return 0;
        }
    }
}
        