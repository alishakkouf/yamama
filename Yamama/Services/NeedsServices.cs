using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yamama.Models;
using Yamama.Repository;

namespace Yamama.Services
{
    public class NeedsServices : INeeds
    {
        private readonly yamamaContext _db;
        public NeedsServices(yamamaContext db)
        {
            _db = db;

        }
        public async Task<ActualNeeds> GetDailyActualNeeds(int id)
        {
            var item = await _db.ActualNeeds.FirstAsync(v => v.IdactualNeeds == id);
            return item;
        }

        public async Task<ExpectedNeeds> GetDailyExpectedNeeds(int id)
        {
            var item = await _db.ExpectedNeeds.FirstAsync(v => v.IdexptedNeeds == id);
            return item;
        }
        public async Task<int> AddActualNeeds(ActualNeeds actual)
        {
            if (_db != null)
            {

                await _db.ActualNeeds.AddAsync(actual);
                await _db.SaveChangesAsync();
                return 1;
            }
            return 0;
        }

        public async Task<int> AddExpectedNeeds(ExpectedNeeds expected)
        {
            if (_db != null)
            {

                await _db.ExpectedNeeds.AddAsync(expected);
                await _db.SaveChangesAsync();
                return 1;
            }
            return 0;
        }

        

        public async Task<List<double>> GetActualNeedsByType(int type, string period, DateTime start, DateTime end)
        {
            try
            {
                if (period == "daily")
                {
                    //Define list of Actual needs each day to store the result
                    List<Double> result = new List<double>();

                    TimeSpan diff = end.Subtract(start);
                    for (var day = start.Date; day <= end.Date; day = day.AddDays(1))
                    {
                        //to store the full productions

                        Double value = 0;

                        string test = day.ToString("yyyy-MM-dd");
                        //return list of Idactualneeds in each day
                        List<int> actualneeds = _db.ActualNeeds.Where(x => x.Date.ToString() == test && x.ProductId == type)
                                                                     .Select(x => x.IdactualNeeds).ToList();



                        for (int j = 0; j < actualneeds.Count; j++)
                        {
                            ActualNeeds subResult = await GetDailyActualNeeds(actualneeds[j]);
                            value += Convert.ToDouble(subResult.ActualNeeds1.Value);
                        }
                        result.Add(value);

                    }
                    return result;
                }
                else if(period == "monthly")
                {
                    //Define list of Actual Needs to store the result
                    List<Double> result = new List<double>();
                    TimeSpan diff = end.Subtract(start);
                    for (var month = start.Month; month <= end.Month; month++)
                    {
                        //to store the all actual needs
                        Double value = 0;

                        //return list of id actual needs in each day
                        List<int> actualneeds = await _db.ActualNeeds.Where(x => x.Date.Value.Month == month && x.ProductId == type)
                        .Select(x => x.IdactualNeeds).ToListAsync();
                        
                        for (int j = 0; j < actualneeds.Count; j++)
                        {
                            ActualNeeds subResult = await GetDailyActualNeeds(actualneeds[j]);
                            value += Convert.ToDouble(subResult.ActualNeeds1.Value);

                        }
                        result.Add(value);
                    }


                    return result;
                }
                else if (period == "annual")
                {
                    //Define list of Actual Needs to store the result
                    List<Double> result = new List<double>();
                    System.TimeSpan diff = end.Subtract(start);
                    for (var year = start.Year; year <= end.Year; year++)
                    {
                        //to store the full Actual Needs
                        Double value = 0;

                        //return list of id_Actual Needs in each day
                        List<int> actualneeds = await _db.ActualNeeds.Where(x => x.Date.Value.Year == year && x.ProductId == type)
                        .Select(x => x.IdactualNeeds).ToListAsync();
                        
                        for (int j = 0; j < actualneeds.Count; j++)
                        {
                            ActualNeeds subResult = await GetDailyActualNeeds(actualneeds[j]);
                            value += Convert.ToDouble(subResult.ActualNeeds1.Value);

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

        

        public async Task<List<double>> GetExpectedNeedsByType(int type, string period, DateTime start, DateTime end)
        {
            try
            {
                if (period == "daily")
                {
                    //Define list of Expected needs each day to store the result
                    List<Double> result = new List<double>();

                    TimeSpan diff = end.Subtract(start);
                    for (var day = start.Date; day <= end.Date; day = day.AddDays(1))
                    {
                        //to store the full Expected needs

                        Double value = 0;

                        string test = day.ToString("yyyy-MM-dd");
                        //return list of Id expectedneeds in each day
                        List<int> expectedneeds = _db.ExpectedNeeds.Where(x => x.Date.ToString() == test && x.ProductId == type)
                                                                     .Select(x => x.IdexptedNeeds).ToList();



                        for (int j = 0; j < expectedneeds.Count; j++)
                        {
                            ExpectedNeeds subResult = await GetDailyExpectedNeeds(expectedneeds[j]);
                            value += Convert.ToDouble(subResult.ExpectedNeeds1.Value);
                        }
                        result.Add(value);

                    }
                    return result;
                }
                else if (period == "monthly")
                {
                    //Define list of Actual Needs to store the result
                    List<Double> result = new List<double>();
                    TimeSpan diff = end.Subtract(start);
                    for (var month = start.Month; month <= end.Month; month++)
                    {
                        //to store the all actual needs
                        Double value = 0;

                        //return list of id actual needs in each day
                        List<int> expectedneeds = await _db.ExpectedNeeds.Where(x => x.Date.Value.Month == month && x.ProductId == type)
                        .Select(x => x.IdexptedNeeds).ToListAsync();

                        for (int j = 0; j < expectedneeds.Count; j++)
                        {
                            ExpectedNeeds subResult = await GetDailyExpectedNeeds(expectedneeds[j]);
                            value += Convert.ToDouble(subResult.ExpectedNeeds1.Value);

                        }
                        result.Add(value);
                    }


                    return result;
                }
                else if (period == "annual")
                {
                    //Define list of Actual Needs to store the result
                    List<Double> result = new List<double>();
                    System.TimeSpan diff = end.Subtract(start);
                    for (var year = start.Year; year <= end.Year; year++)
                    {
                        //to store the full Actual Needs
                        Double value = 0;

                        //return list of id_Actual Needs in each day
                        List<int> expectedneeds = await _db.ExpectedNeeds.Where(x => x.Date.Value.Year == year && x.ProductId == type)
                        .Select(x => x.IdexptedNeeds).ToListAsync();

                        for (int j = 0; j < expectedneeds.Count; j++)
                        {
                            ExpectedNeeds subResult = await GetDailyExpectedNeeds(expectedneeds[j]);
                            value += Convert.ToDouble(subResult.ExpectedNeeds1.Value);

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

        public async Task<int> UpdateActualNeeds(int id, ActualNeeds actual)
        {
            if (_db != null)
            {
                ActualNeeds existItem = _db.ActualNeeds.Where(f => f.IdactualNeeds == id).FirstOrDefault();
                if (existItem != null)
                {
                    existItem.ActualNeeds1 = actual.ActualNeeds1;
                    existItem.Date = actual.Date;
                    existItem.ProductId  = actual.ProductId;
                    }

                _db.ActualNeeds.Update(existItem);
                await _db.SaveChangesAsync();
                return 1;

            }
            return 0;
        }

        public async Task<int> UpdateExpectedNeeds(int id, ExpectedNeeds expected)
        {
            if (_db != null)
            {
                ExpectedNeeds existItem = _db.ExpectedNeeds.Where(f => f.IdexptedNeeds == id).FirstOrDefault();
                if (existItem != null)
                {
                    existItem.ExpectedNeeds1 = expected.ExpectedNeeds1;
                    existItem.Date = expected.Date;
                    existItem.ProductId = expected.ProductId;
                }

                _db.ExpectedNeeds.Update(existItem);
                await _db.SaveChangesAsync();
                return 1;

            }
            return 0;
        }

        public async Task<int> DeleteActualNeeds(int id)
        {
            if (_db != null)
            {
                var item = _db.ActualNeeds.FirstOrDefault(p => p.IdactualNeeds == id);

                if (item != null)
                {
                    _db.ActualNeeds.Remove(item);
                    await _db.SaveChangesAsync();
                    return 1;
                }
            }
            return 0;
        }

        public async Task<int> DeleteExpectedNeeds(int id)
        {
            if (_db != null)
            {
                var item = _db.ExpectedNeeds.FirstOrDefault(p => p.IdexptedNeeds == id);

                if (item != null)
                {
                    _db.ExpectedNeeds.Remove(item);
                    await _db.SaveChangesAsync();
                    return 1;
                }
            }
            return 0;
        }
    }
}
