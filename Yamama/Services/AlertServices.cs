using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yamama.Models;
using Yamama.Repository;
using Yamama.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Yamama.Services
{
    public class AlertServices : IAlert
    {
        private readonly yamamadbContext _db;


        public AlertServices(yamamadbContext db)
        {
            _db = db;
        }
        public async Task<int> AddAlert(TaskTypeViewModel taskTypeViewModel)
        {
            if (_db != null)
            {

                await _db.Alert.AddAsync(taskTypeViewModel.alert);
                await _db.SaveChangesAsync();
                return 1;
            }
            return 0;
        }

        //select all visits whith status is Done (Assume TaskStatus:1=ToDo, 2=Doing, 3=Done, 4=New)
        //the status from Task where the type is Visit (Assume TaskType:1=Visit, 2=Alert, 3=ASk for information)
        public async Task<List<Alert>> ArchiveAlert()
        {
            if (_db != null)
            {


                List<int> tasks = await _db.Task.Where(x => x.StatusId == 3 && x.TypeId == 2)
                            .Select(x => x.Idtask).ToListAsync();
                var alerts = new List<Alert>();
                for (int j = 0; j < tasks.Count; j++)
                {
                    alerts = await _db.Alert.Where(x => x.TaskId == tasks[j])
                        .ToListAsync();
                }
                return alerts;


            }
            return null;
        }

        public async Task<int> DeleteAlert(int id)
        {
            if (_db != null)
            {
                var item = _db.Alert.FirstOrDefault(p => p.Idalert == id);

                if (item != null)
                {
                    _db.Alert.Remove(item);
                    await _db.SaveChangesAsync();
                    return 1;
                }
                
            }
            return 0;
        }

        public async Task<Alert> GetAlert(int id)
        {
            var item = await _db.Alert.FirstOrDefaultAsync(v => v.Idalert == id);
            return item;
        }

        public async Task<List<Alert>> GetAllAlerts()
        {
            if (_db != null)
            {
                var item = await _db.Alert.ToListAsync();
                return item;
            }
            return null;
        }

        public async Task<List<Alert>> NewAssignedAlerts()
        {
            if (_db != null)
            {

                List<int> tasks = await _db.Task.Where(x => x.StatusId == 4 && x.TypeId == 2)
                            .Select(x => x.Idtask).ToListAsync();
                var alerts = new List<Alert>();
                for (int j = 0; j < tasks.Count; j++)
                {
                    alerts = await _db.Alert.Where(x => x.TaskId == tasks[j])
                        .ToListAsync();
                }
                return alerts;

            }
            return null;
        }

        public async Task<int> UpdateAlert(int id, TaskTypeViewModel taskTypeViewModel)
        {
            if (_db != null)
            {
                Alert existItem = _db.Alert.Where(f => f.Idalert == id).FirstOrDefault();
                if (existItem != null)
                {
                    existItem.SenderId = taskTypeViewModel.alert.SenderId;
                    existItem.RecieverId = taskTypeViewModel.alert.RecieverId;
                    existItem.Notes = taskTypeViewModel.alert.Notes;
                    existItem.FileId = taskTypeViewModel.alert.FileId;
                    existItem.SenderId = taskTypeViewModel.alert.TaskId;

                }

                _db.Alert.Update(existItem);
                await _db.SaveChangesAsync();
                return 1;

            }
            return 0;
        }
    }
}
