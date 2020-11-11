using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Yamama.Models;
using Yamama.ViewModels;

namespace Yamama.Repository
{
   public interface IRequestInformation
    {
        Task<int> AddRequestInfo(TaskTypeViewModel taskTypeViewModel);
        Task<RequestInformation> GetRequest(int id);
        Task<List<RequestInformation>> GetAllRequestInfo();
        Task<List<RequestInformation>> NewAssignedRequestInfo();
        Task<List<RequestInformation>> ArchiveRequestInfo();
        Task<int> UpdateRequestInfo(int id, TaskTypeViewModel taskTypeViewModel);
        Task<int> DeleteRequestInfo(int id);
    }
}
