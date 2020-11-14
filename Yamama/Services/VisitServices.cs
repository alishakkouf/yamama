using System;
using System.Collections.Generic;
using System.Linq;
using Yamama.Repository;

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Yamama.ViewModels;
using System.IO;

namespace Yamama.Services
{
    public class VisitServices : IVisit
    {
        private readonly yamamadbContext _db;


        public VisitServices(yamamadbContext db)
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
                List<int> tasks = await _db.Task.Where(x => x.StatusId == 3 && x.TypeId == 1)
                            .Select(x => x.Idtask).ToListAsync();
                var visits = new List<Visit>();
                for (int j = 0; j < tasks.Count; j++)
                {
                    visits = await _db.Visit.Where(x => x.TaskId == tasks[j])
                        .ToListAsync();
                }
                return visits;


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

                List<int> tasks = await _db.Task.Where(x => x.StatusId == 4 && x.TypeId == 1)
                            .Select(x => x.Idtask).ToListAsync();
                var visits = new List<Visit>();
                for (int j = 0; j < tasks.Count; j++)
                {
                    visits = await _db.Visit.Where(x => x.TaskId == tasks[j])
                        .ToListAsync();
                }
                return visits;
            }
            return null;
        }


        //Generating Report for a specific Visit by it's id
        public async Task<Visit> GetVisitbyID(int id)
        {
            var item = await _db.Visit.FirstOrDefaultAsync(v => v.Idvisit == id);

            return item;


        }

        //Get All Visits By the salesman and the client who could be either project or factory
        public async Task<List<(string, string, double)>> GetVisitReports(string salesman, string projectName, string factoryName, string period, DateTime start, DateTime end)
        {
            try
            {
                if (period == "monthly")
                {
                    //Define list of visits to store the result
                    List<(string, string, Double)> result = new List<(string, string, double)>();
                   var clientName = string.Empty;
                   var userId = _db.Aspnetusers.Where(x => x.FullName == salesman).Select(x => x.Id).SingleOrDefault();
                    for (var month = start.Month; month <= end.Month; month++)
                    {
                        //to store the all visits
                        Double value = 0;

                        //return list of id tasks in each month which the salesman was responsible for
                        List<int> tasks = await _db.Task.Where(x => x.StartDate.Value.Month == month && x.ResponsibleId == userId)
                            .Select(x => x.Idtask).ToListAsync();
                        List<int> visits = new List<int>();
                        for (int j = 0; j < tasks.Count; j++)
                        {
                            if (factoryName != null)
                            {
                                var factoryId = _db.Factory.Where(x => x.Name == factoryName).Select(x => x.Idfactory).FirstOrDefault();
                                var one = await _db.Visit.Where(x => x.TaskId == tasks[j] && x.FactoryId == factoryId)
                                    .Select(x => x.Idvisit).SingleOrDefaultAsync();
                                if (one != 0)
                                {
                                    visits.Add(one);
                                }
                                clientName = factoryName;
                            }
                            else if (projectName != null)
                            {
                                var projectId = _db.Project.Where(x => x.Name == projectName).Select(x => x.Idproject).FirstOrDefault();
                                var one = await _db.Visit.Where(x => x.TaskId == tasks[j] && x.ProjectId == projectId)
                                    .Select(x => x.Idvisit).SingleOrDefaultAsync();
                                if (one != 0)
                                {
                                    visits.Add(one);
                                }
                                clientName = projectName;
                            }
                        }
                        for (int j = 0; j < visits.Count; j++)
                        {
                            value = value + 1;
                        }


                       result.Add((salesman, clientName, value));
                    }


                    return result;
                }
                else if (period == "annual")
                {
                    //Define list of visits to store the result
                    List<(string, string, Double)> result = new List<(string, string, double)>();
                    var clientName = string.Empty;
                   var userId = _db.Aspnetusers.Where(x => x.FullName == salesman).Select(x => x.Id).SingleOrDefault();
                    for (var year = start.Year; year <= end.Year; year++)
                    {
                        //to store the full sales
                        Double value = 0;

                        //return list of id tasks in each year
                        List<int> tasks = await _db.Task.Where(x => x.StartDate.Value.Year == year && x.ResponsibleId == userId)
                            .Select(x => x.Idtask).ToListAsync();
                        //return list of id visits in each year
                        List<int> visits = new List<int>();
                        for (int j = 0; j < tasks.Count; j++)
                        {
                            if (factoryName != null)
                            {
                                var factoryId = _db.Factory.Where(x => x.Name == factoryName).Select(x => x.Idfactory).FirstOrDefault();
                                var one = await _db.Visit.Where(x => x.TaskId == tasks[j] && x.FactoryId == factoryId)
                                    .Select(x => x.Idvisit).SingleOrDefaultAsync();
                                if (one != 0)
                                {
                                    visits.Add(one);
                                }
                                clientName = factoryName;
                            }
                            else if (projectName != null)
                            {
                                var projectId = _db.Project.Where(x => x.Name == projectName).Select(x => x.Idproject).FirstOrDefault();
                                var one = await _db.Visit.Where(x => x.TaskId == tasks[j] && x.ProjectId == projectId)
                                    .Select(x => x.Idvisit).SingleOrDefaultAsync();
                                if (one != 0)
                                {
                                    visits.Add(one);
                                }
                                clientName = projectName;
                            }
                        }
                        for (int j = 0; j < visits.Count; j++)
                        {
                            value++;
                        }

                        result.Add((userId, clientName, value));
                    }


                    return result;
                }
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public async Task<List<(string, Double)>> GetVisisBySalesman(string salesman, string period, DateTime start, DateTime end)
        {
            try
            {
                if (period == "daily")
                {
                    //Define list of visits each day to store the result
                    List<(string, Double)> result = new List<(string, double)>();
                    var userId = _db.Aspnetusers.Where(x => x.FullName == salesman).Select(x => x.Id).SingleOrDefault();

                    for (var day = start.Date; day <= end.Date; day = day.AddDays(1))
                    {
                        //to store the all visits

                        Double value = 0;

                        string test = day.ToString("yyyy-MM-dd");
                        //return list of Idvisits in each day

                        List<int> tasks = _db.Task.Where(x => x.StartDate.ToString() == test && x.ResponsibleId == userId)
                            .Select(x => x.Idtask).ToList();
                        List<int> visits = new List<int>();
                        for (int j = 0; j < tasks.Count; j++)
                        {
                            var one = _db.Visit.Where(x => x.TaskId == tasks[j])
                                .Select(x => x.Idvisit).SingleOrDefault();
                            if (one != 0)
                            {
                                visits.Add(one);
                            }
                        }
                        for (int j = 0; j < visits.Count; j++)
                        {
                            value++;
                        }
                        result.Add((salesman, value));

                    }
                    return result;
                }
                else if (period == "monthly")
                {
                    //Define list of productions to store the result
                    List<(string, Double)> result = new List<(string, double)>();
                    var userId = _db.Aspnetusers.Where(x => x.FullName == salesman).Select(x => x.Id).SingleOrDefault();
                    for (var month = start.Month; month <= end.Month; month++)
                    {
                        //to store the full visits
                        Double value = 0;

                        //return list of idvisit in each day
                        List<int> tasks = await _db.Task.Where(x => x.StartDate.Value.Month == month && x.ResponsibleId == userId)
                            .Select(x => x.Idtask).ToListAsync();
                        List<int> visits = new List<int>();
                        for (int j = 0; j < tasks.Count; j++)
                        {
                            var one = _db.Visit.Where(x => x.TaskId == tasks[j])
                                .Select(x => x.Idvisit).SingleOrDefault();
                            if (one != 0)
                            {
                                visits.Add(one);
                            }
                        }
                        for (int j = 0; j < visits.Count; j++)
                        {
                            value++;
                        }


                        result.Add((salesman, value));
                    }


                    return result;
                }
                else if (period == "annual")
                {
                    //Define list of visits to store the result
                    List<(string, Double)> result = new List<(string, double)>();
                    var userId = _db.Aspnetusers.Where(x => x.FullName == salesman).Select(x => x.Id).SingleOrDefault();

                    for (var year = start.Year; year <= end.Year; year++)
                    {
                        //to store the all visits
                        Double value = 0;

                        //return list of idvisit in each day
                        List<int> tasks = await _db.Task.Where(x => x.StartDate.Value.Year == year && x.ResponsibleId == userId)
                            .Select(x => x.Idtask).ToListAsync();
                        List<int> visits = new List<int>();
                        for (int j = 0; j < tasks.Count; j++)
                        {
                            var one = _db.Visit.Where(x => x.TaskId == tasks[j])
                                .Select(x => x.Idvisit).SingleOrDefault();
                            if (one != 0)
                            {
                                visits.Add(one);
                            }
                        }
                        for (int j = 0; j < visits.Count; j++)
                        {
                            value++;
                        }

                        result.Add((salesman, value));
                    }


                    return result;
                }
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public async Task<List<(string, Double)>> GetVisitsByClient(string projectName, string factoryName, string period, DateTime start, DateTime end)


        {
            try
            {
                if (period == "daily")
                {
                    //Define list of visits each day to store the result
                    List<(string, Double)> result = new List<(string, double)>();
                    var clientName = string.Empty;
                    for (var day = start.Date; day <= end.Date; day = day.AddDays(1))
                    {
                        //to store the full visits

                        Double value = 0;

                        string test = day.ToString("yyyy-MM-dd");
                        //return list of Idvisits in each day

                        List<int> tasks = _db.Task.Where(x => x.StartDate.ToString() == test)
                            .Select(x => x.Idtask).ToList();
                        List<int> visits = new List<int>();
                        for (int j = 0; j < tasks.Count; j++)
                        {
                            if (factoryName != null)
                            {
                                var factoryId = _db.Factory.Where(x => x.Name == factoryName).Select(x=>x.Idfactory).FirstOrDefault();
                                var one = await _db.Visit.Where(x => x.TaskId == tasks[j] && x.FactoryId == factoryId)
                                    .Select(x => x.Idvisit).SingleOrDefaultAsync();
                                if (one != 0)
                                {
                                    visits.Add(one);
                                }
                                clientName = factoryName;
                            }
                            else if (projectName != null)
                            {
                                var projectId = _db.Project.Where(x => x.Name == projectName).Select(x => x.Idproject).FirstOrDefault();
                                var one = await _db.Visit.Where(x => x.TaskId == tasks[j] && x.ProjectId == projectId)
                                    .Select(x => x.Idvisit).SingleOrDefaultAsync();
                                if (one != 0)
                                {
                                    visits.Add(one);
                                }
                                clientName = projectName;
                            }
                        }
                        for (int j = 0; j < visits.Count; j++)
                        {
                            value++;
                        }
                        result.Add((clientName, value));

                    }
                    return result;
                }
                else if (period == "monthly")
                {
                    //Define list of visits to store the result
                    List<(string, Double)> result = new List<(string, double)>();
                    var clientName = string.Empty;
                    for (var month = start.Month; month <= end.Month; month++)
                    {
                        //to store the all visits]
                        Double value = 0;

                        //return list of idvisit in each month
                        List<int> tasks = _db.Task.Where(x => x.StartDate.Value.Month == month && x.TypeId == 1)
                            .Select(x => x.Idtask).ToList();
                        List<int> visits = new List<int>();
                        for (int j = 0; j < tasks.Count; j++)
                        {
                            if (factoryName != null)
                            {
                                var factoryId = _db.Factory.Where(x => x.Name == factoryName).Select(x => x.Idfactory).FirstOrDefault();
                                var one = await _db.Visit.Where(x => x.TaskId == tasks[j] && x.FactoryId == factoryId)
                                    .Select(x => x.Idvisit).SingleOrDefaultAsync();
                                if (one != 0)
                                {
                                    visits.Add(one);
                                }
                                clientName = factoryName;
                            }
                            else if (projectName != null)
                            {
                                var projectId = _db.Project.Where(x => x.Name == projectName).Select(x => x.Idproject).FirstOrDefault();
                                var one = await _db.Visit.Where(x => x.TaskId == tasks[j] && x.ProjectId == projectId)
                                    .Select(x => x.Idvisit).SingleOrDefaultAsync();
                                if (one != 0)
                                {
                                    visits.Add(one);
                                }
                                clientName = projectName;
                            }
                        }
                        for (int j = 0; j < visits.Count; j++)
                        {
                            value++;
                        }


                        result.Add((clientName, value));
                    }


                    return result;
                }
                else if (period == "annual")
                {
                    //Define list of visits to store the result
                    List<(string, Double)> result = new List<(string, double)>();
                    var clientName = string.Empty;
                    for (var year = start.Year; year <= end.Year; year++)
                    {
                        //to store the all visits
                        Double value = 0;

                        //return list of idvisit in each year
                        List<int> tasks = await _db.Task.Where(x => x.StartDate.Value.Year == year)
                            .Select(x => x.Idtask).ToListAsync();
                        List<int> visits = new List<int>();
                        for (int j = 0; j < tasks.Count; j++)
                        {
                            if (factoryName != null)
                            {
                                var factoryId = _db.Factory.Where(x => x.Name == factoryName).Select(x => x.Idfactory).FirstOrDefault();
                                var one = await _db.Visit.Where(x => x.TaskId == tasks[j] && x.FactoryId == factoryId)
                                    .Select(x => x.Idvisit).SingleOrDefaultAsync();
                                if (one != 0)
                                {
                                    visits.Add(one);
                                }
                                clientName = factoryName;
                            }
                            else if (projectName != null)
                            {
                                var projectId = _db.Project.Where(x => x.Name == projectName).Select(x => x.Idproject).FirstOrDefault();
                                var one = await _db.Visit.Where(x => x.TaskId == tasks[j] && x.ProjectId == projectId)
                                    .Select(x => x.Idvisit).SingleOrDefaultAsync();
                                if (one != 0)
                                {
                                    visits.Add(one);
                                }
                                clientName = projectName;
                            }
                        }
                        for (int j = 0; j < visits.Count; j++)
                        {
                            value++;
                        }

                        result.Add((clientName, value));
                    }


                    return result;
                }
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public async Task<int> UpdateVisit(int id, TaskTypeViewModel taskTypeViewModel)
        {
            if (_db != null)
            {
                Visit existItem = _db.Visit.Where(f => f.Idvisit == id).FirstOrDefault();
                if (existItem != null)
                {
                    existItem.UserId = taskTypeViewModel.visit.UserId;
                    existItem.FactoryId = taskTypeViewModel.visit.FactoryId;
                    existItem.ProjectId = taskTypeViewModel.visit.ProjectId;
                    existItem.TaskId = taskTypeViewModel.visit.TaskId;
                    existItem.Gifts = taskTypeViewModel.visit.Gifts;
                    existItem.Notes = taskTypeViewModel.visit.Notes;


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

        ////////////with no async just for calculation in target service
        public List<Double> GetVistisBySalesmanRepo(string salesman, string period, DateTime start, DateTime end)
        {
            try
            {
                if (period == "daily")
                {
                    //Define list of visits each day to store the result
                    List<Double> result = new List<double>();
                    var userId = _db.Aspnetusers.Where(x => x.FullName == salesman).Select(x => x.Id).SingleOrDefault();
                    for (var day = start.Date; day <= end.Date; day = day.AddDays(1))
                    {
                        //to store the all visits

                        Double value = 0;

                        string test = day.ToString("yyyy-MM-dd");
                        //return list of Idvisits in each day

                        List<int> tasks = _db.Task.Where(x => x.StartDate.ToString() == test && x.ResponsibleId == userId)
                            .Select(x => x.Idtask).ToList();
                        List<int> visits = new List<int>();
                        for (int j = 0; j < tasks.Count; j++)
                        {
                            var one = _db.Visit.Where(x => x.TaskId == tasks[j])
                                .Select(x => x.Idvisit).SingleOrDefault();
                            if (one != 0)
                            {
                                visits.Add(one);
                            }
                        }
                        for (int j = 0; j < visits.Count; j++)
                        {
                            value++;
                        }
                        result.Add(value);

                    }
                    return result;
                }
                else if (period == "monthly")
                {
                    //Define list of productions to store the result
                    List<Double> result = new List<double>();
                    var userId = _db.Aspnetusers.Where(x => x.FullName == salesman).Select(x => x.Id).SingleOrDefault();
                    for (var month = start.Month; month <= end.Month; month++)
                    {
                        //to store the full visits
                        Double value = 0;

                        //return list of idvisit in each day
                        List<int> tasks = _db.Task.Where(x => x.StartDate.Value.Month == month && x.ResponsibleId == userId)
                            .Select(x => x.Idtask).ToList();
                        List<int> visits = new List<int>();
                        for (int j = 0; j < tasks.Count; j++)
                        {

                            var one = _db.Visit.Where(x => x.TaskId == tasks[j])
                                .Select(x => x.Idvisit).ToList();
                            foreach (var item in one)
                            {
                                if (item != 0)
                                {
                                    visits.Add(item);
                                }
                            }
                        }
                        for (int j = 0; j < visits.Count; j++)
                        {
                            value++;
                        }


                        result.Add(value);
                    }


                    return result;
                }
                else if (period == "annual")
                {
                    //Define list of visits to store the result
                    List<Double> result = new List<double>();
                    var userId = _db.Aspnetusers.Where(x => x.FullName == salesman).Select(x => x.Id).SingleOrDefault();
                    for (var year = start.Year; year <= end.Year; year++)
                    {
                        //to store the all visits
                        Double value = 0;

                        //return list of idvisit in each day
                        List<int> tasks = _db.Task.Where(x => x.StartDate.Value.Year == year && x.ResponsibleId == userId)
                            .Select(x => x.Idtask).ToList();
                        List<int> visits = new List<int>();
                        for (int j = 0; j < tasks.Count; j++)
                        {

                            var one = _db.Visit.Where(x => x.TaskId == tasks[j])
                                .Select(x => x.Idvisit).ToList();
                            foreach (var item in one)
                            {
                                if (item != 0)
                                {
                                    visits.Add(item);
                                }
                            }

                        }
                        for (int j = 0; j < visits.Count; j++)
                        {
                            value++;
                        }

                        result.Add(value);
                    }


                    return result;
                }
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}