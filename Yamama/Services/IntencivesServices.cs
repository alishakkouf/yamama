using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Yamama.Models;
using Yamama.Repository;

namespace Yamama.Services
{
    public class IntencivesServices : IIntencive
    {
            private readonly yamamadbContext _db;
            public IntencivesServices(yamamadbContext db)
            {
                _db = db;

            }
            public async Task<ActualIntencive> GetDailyActualIntencive(int id)
            {
                var item = await _db.ActualIntencive.FirstAsync(v => v.IdactualIntencive == id);
                return item;
            }

            public async Task<ExpectedIntencive> GetDailyExpectedIntencive(int id)
            {
                var item = await _db.ExpectedIntencive.FirstAsync(v => v.IdexpectedIntencive == id);
                return item;
            }
            public async Task<int> AddActualIntencive(ActualIntencive actual)
            {
                if (_db != null)
                {

                    await _db.ActualIntencive.AddAsync(actual);
                    await _db.SaveChangesAsync();
                    return 1;
                }
                return 0;
            }

            public async Task<int> AddExpectedIntencive(ExpectedIntencive expected)
            {
                if (_db != null)
                {
                

                    await _db.ExpectedIntencive.AddAsync(expected);
                    await _db.SaveChangesAsync();
                    return 1;
                }
                return 0;
            }



        public async Task<List<(string, double)>> GetActualIntenciveByUser(string user, string period, DateTime start, DateTime end)
        {

            
            try
            {
                if (period == "monthly")
                {
                    //Define list of Actual intencives to store the result
                    List<(string, double)> result = new List<(string, double)>();
                    for (var month = start.Month; month <= end.Month; month++)
                    {
                        //to store the all actual intencives
                        Double value = 0;

                        //return list of id actual intencives in each month
                        List<int> actualintencives = await _db.ActualIntencive
                            .Where(x => x.Date.Value.Month == month && x.IdUser == user)
                            .Select(x => x.IdactualIntencive).ToListAsync();
                        var userName = _db.Aspnetusers.Where(x => x.Id == user).Select(x => x.FullName).SingleOrDefault();
                        for (int j = 0; j < actualintencives.Count; j++)
                        {
                            ActualIntencive subResult = await GetDailyActualIntencive(actualintencives[j]);
                            value += Convert.ToDouble(subResult.ActualIntencive1.Value);

                        }
                        result.Add((userName, value));

                    }


                    return result;
                }
                else if (period == "annual")
                {
                    //Define list of Actual intencives to store the result
                    List<(string, double)> result = new List<(string, double)>();
                    var userName = _db.Aspnetusers.Where(x => x.Id == user).Select(x => x.FullName).SingleOrDefault();
                    for (var year = start.Year; year <= end.Year; year++)
                    {
                        //to store the full Actual intencives
                        Double value = 0;

                        //return list of id_Actual intencives in each day
                        List<int> actualintencives = await _db.ActualIntencive
                            .Where(x => x.Date.Value.Year == year && x.IdUser == user)
                            .Select(x => x.IdactualIntencive).ToListAsync();

                        for (int j = 0; j < actualintencives.Count; j++)
                        {
                            ActualIntencive subResult = await GetDailyActualIntencive(actualintencives[j]);
                            value += Convert.ToDouble(subResult.ActualIntencive1.Value);

                        }
                        result.Add((userName, value));
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



        public async Task<List<(string, double)>> GetExpectedIntenciveByUser(string user, string period, DateTime start, DateTime end)
        {
            try
            {
                if (period == "monthly")
                {
                    //Define list of Expected intencive to store the result
                    List<(string, double)> result = new List<(string, double)>();
                    var userName = _db.Aspnetusers.Where(x => x.Id == user).Select(x => x.FullName).SingleOrDefault();
                    for (var month = start.Month; month <= end.Month; month++)
                    {
                        //to store the all expected intencive
                        Double value = 0;

                        //return list of id expected intencive in each day
                        List<int> expectedintencive = await _db.ExpectedIntencive
                            .Where(x => x.Date.Value.Month == month && x.UserId == user)
                            .Select(x => x.IdexpectedIntencive).ToListAsync();

                        for (int j = 0; j < expectedintencive.Count; j++)
                        {
                            ExpectedIntencive subResult = await GetDailyExpectedIntencive(expectedintencive[j]);
                            value += Convert.ToDouble(subResult.ExpectedMoney);

                        }
                        result.Add((userName, value));
                    }


                    return result;
                }
                else if (period == "annual")
                {
                    //Define list of expected intencive to store the result
                    List<(string, double)> result = new List<(string, double)>();
                    var userName = _db.Aspnetusers.Where(x => x.Id == user).Select(x => x.FullName).SingleOrDefault();
                    for (var year = start.Year; year <= end.Year; year++)
                    {
                        //to store the full expected intencive
                        Double value = 0;

                        //return list of id_expected intencive in each day
                        List<int> expectedintencive = await _db.ExpectedIntencive
                            .Where(x => x.Date.Value.Year == year && x.UserId == user)
                            .Select(x => x.IdexpectedIntencive).ToListAsync();

                        for (int j = 0; j < expectedintencive.Count; j++)
                        {
                            ExpectedIntencive subResult = await GetDailyExpectedIntencive(expectedintencive[j]);
                            value += Convert.ToDouble(subResult.ExpectedMoney);

                        }
                        result.Add((userName, value));
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

        public async Task<int> UpdateActualIntencive(int id, ActualIntencive actual)
            {
                if (_db != null)
                {
                    ActualIntencive existItem = _db.ActualIntencive
                    .Where(f => f.IdactualIntencive == id).FirstOrDefault();
                    if (existItem != null)
                    {
                        existItem.ActualIntencive1 = actual.ActualIntencive1;
                        existItem.Date = actual.Date;
                        existItem.IdUser = actual.IdUser;
                    }

                    _db.ActualIntencive.Update(existItem);
                    await _db.SaveChangesAsync();
                    return 1;

                }
                return 0;
            }

            public async Task<int> UpdateExpectedIntencive(int id, ExpectedIntencive expected)
            {
                if (_db != null)
                {
                    ExpectedIntencive existItem = _db.ExpectedIntencive
                    .Where(f => f.IdexpectedIntencive == id).FirstOrDefault();
                    if (existItem != null)
                    {
                        existItem.ExpectedMoney = expected.ExpectedMoney;
                        existItem.Date = expected.Date;
                        existItem.UserId = expected.UserId;
                    }

                    _db.ExpectedIntencive.Update(existItem);
                    await _db.SaveChangesAsync();
                    return 1;

                }
                return 0;
            }

            public async Task<int> DeleteActualIntencive(int id)
            {
                if (_db != null)
                {
                    var item = _db.ActualIntencive.FirstOrDefault(p => p.IdactualIntencive == id);

                    if (item != null)
                    {
                        _db.ActualIntencive.Remove(item);
                        await _db.SaveChangesAsync();
                        return 1;
                    }
                }
                return 0;
            }

            public async Task<int> DeleteExpectedIntencive(int id)
            {
                if (_db != null)
                {
                    var item = _db.ExpectedIntencive.FirstOrDefault(p => p.IdexpectedIntencive == id);
                if (item != null)
                    {
                    _db.ExpectedIntencive.Remove(item);
                    await _db.SaveChangesAsync();
                    return 1;
                }
            }
            return 0;
        }

        }
}

