using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yamama.Models;
using Yamama.Repository;
using Yamama.ViewModels;

namespace Yamama.Services
{
    public class RequestInformationServices : IRequestInformation
    {
        private readonly yamamaContext _db;


        public RequestInformationServices(yamamaContext db)
        {
            _db = db;
        }

        

        public async Task<int> AddRequestInfo(TaskTypeViewModel taskTypeViewModel)
        {
            if (_db != null)
            {

                await _db.RequestInformation.AddAsync(taskTypeViewModel.reqInfo);
                await _db.SaveChangesAsync();
                return 1;
            }
            return 0;
        }

        

        //select all RequestsInformation whith status is Done (Assume TaskStatus:1=ToDo, 2=Doing, 3=Done, 4=New)
        //the status from Task where the type is ASk for Information (Assume TaskType:1=Visit, 2=Alert, 3=ASk for information)
        public async Task<List<RequestInformation>> ArchiveRequestInfo()
        {
            if (_db != null)
            {


                var item = await(from requstInfo in _db.RequestInformation
                                 join task in _db.Task on requstInfo.IdrequestInformation equals task.Idtask
                                 where task.StatusId == 3 & task.TypeId == 3
                                 select requstInfo).ToListAsync();


                return item;


            }
            return null;
        }

        

        public async Task<int> DeleteRequestInfo(int id)
        {
            if (_db != null)
            {
                var item = _db.RequestInformation.FirstOrDefault(p => p.IdrequestInformation == id);

                if (item != null)
                {
                    _db.RequestInformation.Remove(item);
                    await _db.SaveChangesAsync();
                    return 1;
                }
            }
            return 0;
        }

        public async Task<List<RequestInformation>> GetAllRequestInfo()
        {
            if (_db != null)
            {
                var item = await _db.RequestInformation.ToListAsync();
                return item;
            }
            return null;
        }

        

        public async Task<RequestInformation> GetRequest(int id)
        {
            var item = await _db.RequestInformation.FirstOrDefaultAsync(v => v.IdrequestInformation == id);
            return item;
        }

        

        //select all RequestsInformation whith status is New (Assume TaskStatus:1=ToDo, 2=Doing, 3=Done, 4=New)
        //the status from Task where the type is ASk for Information (Assume TaskType:1=Visit, 2=Alert, 3=ASk for information)
        public async Task<List<RequestInformation>> NewAssignedRequestInfo()
        {
            if (_db != null)
            {

                var item = await(from requestInfo in _db.RequestInformation
                                 join task in _db.Task on requestInfo.IdrequestInformation equals task.Idtask
                                 where task.StatusId == 4 & task.TypeId == 3
                                 select requestInfo).ToListAsync();


                return item;
            }
            return null;
        }

        

        public async Task<int> UpdateRequestInfo(int id, TaskTypeViewModel taskTypeViewModel)
        {
            if (_db != null)
            {
                RequestInformation existItem = _db.RequestInformation.Where(f => f.IdrequestInformation == id).FirstOrDefault();
                if (existItem != null)
                {
                    existItem.SenderId = taskTypeViewModel.reqInfo.SenderId;
                    existItem.RecieverId = taskTypeViewModel.reqInfo.RecieverId;
                    existItem.Notes = taskTypeViewModel.reqInfo.Notes;
                    existItem.FileId = taskTypeViewModel.reqInfo.FileId;
                    existItem.TaskId = taskTypeViewModel.reqInfo.TaskId;

                }

                _db.RequestInformation.Update(existItem);
                await _db.SaveChangesAsync();
                return 1;

            }
            return 0;
        }
    }
}
