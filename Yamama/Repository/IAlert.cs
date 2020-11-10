﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Yamama.Models;
using Yamama.ViewModels;

namespace Yamama.Repository
{
    public interface IAlert
    {
        Task<int> AddAlert(Alert taskTypeViewModel);
        Task<Alert> GetAlert(int id);
        Task<List<Alert>> GetAllAlerts();
        Task<List<Alert>> NewAssignedAlerts();
        Task<List<Alert>> ArchiveAlert();
        Task<int> UpdateAlert(int id, Alert taskTypeViewModel);
        Task<int> DeleteAlert(int id);
    }
}
