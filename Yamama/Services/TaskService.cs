using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yamama.Models;
using Yamama.Repository;
using Microsoft.EntityFrameworkCore;
using Yamama.ViewModels;
using Alexa.NET.Notifications;

using Microsoft.AspNetCore.SignalR;
using Yamama.Controllers;
using System.IO;
using Microsoft.AspNetCore.Hosting;


namespace Yamama.Services
{
    public class TaskService : ITask

    {


   
        private readonly yamamaContext _db;
        public TaskService(yamamaContext db)
        {
            _db = db;
        }
        //Adding new Task 
        //each task has a typeID (1=visit, 2=alert, 3=requestInformation)
        //public async Task<int> AddTask(TaskTypeViewModel taskTypeViewModel, PhotoFileViewModel photoFileViewModel)
        public async Task<int> AddTask(TaskTypeViewModel taskTypeViewModel)
        {
            if (_db != null)
            {
                await _db.Task.AddAsync(taskTypeViewModel.task);

                //if the type is 1=visit so add visit
                if (taskTypeViewModel.task.TypeId == 1)
                {
                    await _db.Visit.AddAsync(taskTypeViewModel.visit);

                    await _db.SaveChangesAsync();

                    return 1;
                }
                //if the type is 2=alert so add alert
                else if (taskTypeViewModel.task.TypeId == 2)
                {
                    await _db.Alert.AddAsync(taskTypeViewModel.alert);
                    await _db.SaveChangesAsync();

                    return 1;
                }
                //if the type is 3=RequestInformation so add RequestInformation
                else if (taskTypeViewModel.task.TypeId == 3)
                {
                    await _db.RequestInformation.AddAsync(taskTypeViewModel.reqInfo);
                    await _db.SaveChangesAsync();
                    return 1;
                }

            }
            return 0;
        }



        //select all tasks whith status is Done (Assume TaskStatus:1=ToDo, 2=Doing, 3=Done, 4=New)
        public async Task<List<Models.Task>> ArchiveTasks()
        {
            if (_db != null)
            {
                var item = await _db.Task.Where(f => f.StatusId == 3).ToListAsync();
                return item;
            }
            return null;
        }

        public async Task<int> DeleteTask(int id)
        {
            if (_db != null)
            {
                Models.Task item = await _db.Task.FirstAsync(p => p.Idtask == id);
                if (item != null)
                {
                    if (item.FileId != null)
                    {
                        var files = _db.File.Where(x => x.Idfile == item.FileId).SingleOrDefault();
                        _db.File.Remove(files);
                    }
                    else if (item.PhotoId != null)
                    {
                        var photos = _db.Photo.Where(x => x.Idphoto == item.PhotoId).SingleOrDefault();
                        _db.Photo.Remove(photos);
                    }

                    if (item.TypeId == 1)
                    {
                        var visit = _db.Visit.First(p => p.TaskId == id);
                        if (visit != null)
                        {
                            _db.Visit.Remove(visit);
                        }
                        _db.Task.Remove(item);
                        await _db.SaveChangesAsync();
                        return 1;
                    }
                    else if (item.TypeId == 2)
                    {
                        var alert = _db.Alert.First(p => p.TaskId == id);
                        if (alert != null)
                        {
                            _db.Alert.Remove(alert);
                        }
                        _db.Task.Remove(item);
                        await _db.SaveChangesAsync();
                        return 1;
                    }

                    else if (item.TypeId == 3)
                    {
                        var reqInfo = _db.RequestInformation.First(p => p.TaskId == id);
                        if (reqInfo != null)
                        {
                            _db.RequestInformation.Remove(reqInfo);
                           
                        }
                        _db.Task.Remove(item);
                        await _db.SaveChangesAsync();
                        return 1;
                    }
                    
                }
                return 0;

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

        //each update maby affect the data of task type
        public async Task<int> UpdateTask(int id, TaskTypeViewModel taskTypeViewModel)
        {
            if (_db != null)
            {
                Models.Task existItem = _db.Task.Where(f => f.Idtask == id).FirstOrDefault();
                if (existItem != null)
                {
                    existItem.Name = taskTypeViewModel.task.Name;
                    //to update each type data
                    if (existItem.TypeId == taskTypeViewModel.task.TypeId)
                    {
                        if (existItem.TypeId == 1)
                        {
                            var existVisit = _db.Visit.Where(f => f.TaskId == id).FirstOrDefault();
                            existVisit.UserId = taskTypeViewModel.visit.UserId;
                            existVisit.FactoryId = taskTypeViewModel.visit.FactoryId;
                            existVisit.ProjectId = taskTypeViewModel.visit.ProjectId;
                            existVisit.Gifts = taskTypeViewModel.visit.Gifts;
                            existVisit.Notes = taskTypeViewModel.visit.Notes;

                            _db.Visit.Update(existVisit);
                        }
                        else if (existItem.TypeId == 2)
                        {
                            var existAlert = _db.Alert.Where(f => f.TaskId == id).FirstOrDefault();
                            existAlert.SenderId = taskTypeViewModel.alert.SenderId;
                            existAlert.RecieverId = taskTypeViewModel.alert.RecieverId;
                            existAlert.Notes = taskTypeViewModel.alert.Notes;
                            existAlert.FileId = taskTypeViewModel.alert.FileId;
                            _db.Alert.Update(existAlert);
                        }
                        else if (existItem.TypeId == 3)
                        {
                            var existRequest = _db.RequestInformation.Where(f => f.TaskId == id).FirstOrDefault();
                            existRequest.SenderId = taskTypeViewModel.reqInfo.SenderId;
                            existRequest.RecieverId = taskTypeViewModel.reqInfo.RecieverId;
                            existRequest.Notes = taskTypeViewModel.reqInfo.Notes;
                            existRequest.FileId = taskTypeViewModel.reqInfo.FileId;
                            _db.RequestInformation.Update(existRequest);
                        }
                    }
                    //user not allowed to change task type
                    else
                    {
                        return 0;
                    }
                    existItem.StatusId = taskTypeViewModel.task.StatusId;
                    existItem.ResponsibleId = taskTypeViewModel.task.ResponsibleId;
                    existItem.CreatorId = taskTypeViewModel.task.CreatorId;
                    existItem.Content = taskTypeViewModel.task.Content;
                    existItem.StartDate = taskTypeViewModel.task.StartDate;
                    existItem.EndDate = taskTypeViewModel.task.EndDate;
                    existItem.FileId = taskTypeViewModel.task.FileId;
                    existItem.PhotoId = taskTypeViewModel.task.PhotoId;
                }

                _db.Task.Update(existItem);
                await _db.SaveChangesAsync();
                return 1;

            }
            return 0;
        }
    }
}
