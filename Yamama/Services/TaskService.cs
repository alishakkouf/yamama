using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yamama.Models;
using Yamama.Repository;
using Microsoft.EntityFrameworkCore;
using Yamama.ViewModels;
using Alexa.NET.Notifications;
//using UrbanAirSharp;

namespace Yamama.Services
{
    public class TaskService: ITask

    {
        private readonly yamamaContext _db;
        public TaskService(yamamaContext db)
        {
            _db = db;
        }
        //Adding new Task
        public async Task<int> AddTask(TaskTypeViewModel taskTypeViewModel)
        {
            if (_db != null)
            {
                await _db.Task.AddAsync(taskTypeViewModel.task);
                await _db.SaveChangesAsync();

                return 1;
            }
            return 0;
        }


        //select all tasks whith status is Done (Assume TaskStatus:1=ToDo, 2=Doing, 3=Done, 4=New)
        public async Task<List<Models.Task>> ArchiveTasks()
        {
            if (_db != null)
            {


                var item = await _db.Task.Where(f => f.TypeId == 3).ToListAsync();


                return item;


            }
            return null;
        }

        //public Task<int> AssignTask(Models.Task task)
        //{
        //    return  
        //}

        public async Task<int> DeleteTask(int id)
        {
            if (_db != null)
            {
                var item = _db.Task.FirstOrDefault(p => p.Idtask == id);

                if (item != null)

                    _db.Task.Remove(item);
                await _db.SaveChangesAsync();
                return 1;

            }
            return 0;
        }

        public async Task<List<Models.Task>> GetAllTasks()
        {
            if (_db != null)
            {
                var item = await _db.Task.ToListAsync();
                return item;
            }
            return null;
        }

        public async Task<Models.Task> GetTask(int id)
        {
            var item = await _db.Task.FirstOrDefaultAsync(v => v.Idtask == id);
            return item;
        }

        //select all tasks whith status is Done (Assume TaskStatus:1=ToDo, 2=Doing, 3=Done, 4=New)
        public async Task<List<Models.Task>> NewAssignedTasks()
        {
            if (_db != null)
            {


                var item = await _db.Task.Where(f => f.StatusId == 4).ToListAsync();


                return item;


            }
            return null;
        }

        public async Task<int> UpdateTask(int id, TaskTypeViewModel taskTypeViewModel)
        {
            if (_db != null)
            {
                Models.Task existItem = _db.Task.Where(f => f.Idtask == id).FirstOrDefault();
                if (existItem != null)
                {
                    existItem.Name = taskTypeViewModel.task.Name;
                    existItem.TypeId = taskTypeViewModel.task.TypeId;
                    existItem.StatusId = taskTypeViewModel.task.StatusId;
                    existItem.ResponsibleId = taskTypeViewModel.task.ResponsibleId;
                    existItem.CreatorId = taskTypeViewModel.task.CreatorId;
                    existItem.Content = taskTypeViewModel.task.Content;
                    existItem.StartDate = taskTypeViewModel.task.StartDate;
                    existItem.EndDate = taskTypeViewModel.task.EndDate;
                }

                _db.Task.Update(existItem);
                await _db.SaveChangesAsync();
                return 1;

            }
            return 0;
        }
    }
}
