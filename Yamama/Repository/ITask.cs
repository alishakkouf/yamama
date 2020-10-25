using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yamama.Models;
using Yamama.ViewModels;

namespace Yamama.Repository
{
    public interface ITask
    {
        Task<int> AddTask(TaskTypeViewModel taskTypeViewModel);
        Task<int> UpdateTask(int id, TaskTypeViewModel taskTypeViewModel);
        Task<int> DeleteTask(int id);
        Task<List<Models.Task>> GetAllTasks();
        //Task<int> AssignTask(Models.Task task);
        Task<Models.Task> GetTask(int id);
        Task<List<Models.Task>> NewAssignedTasks();
        Task<List<Models.Task>> ArchiveTasks();
        
    }
}
