using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Yamama.Repository;
using Yamama.ViewModels;

namespace Yamama.Services
{
    public class TargetServices : ITarget
    {
        private readonly yamamadbContext _db;
        public TargetServices(yamamadbContext db)
        {
            _db = db;
        }
        public async Task<int> AddTarget(Target target)
        {
            if (_db != null)
            {

                await _db.Target.AddAsync(target);
                await _db.SaveChangesAsync();
                return 1;
            }
            return 0;
        }
        public async Task<int> DeleteTarget(int id)
        {
            if (_db != null)
            {
                var item = _db.Target.FirstOrDefault(p => p.Idtarget == id);

                if (item != null)
                {
                    _db.Target.Remove(item);
                    await _db.SaveChangesAsync();
                    return 1;
                }
            }
            return 0;
        }
        public List<Double> GetVisitTartget(string salesman, string period, DateTime start, DateTime end)
        {
            try
            {
                if (period == "monthly")
                {
                    //Define list of visits to store the result
                    List<Double> result = new List<double>();
                    var userId = _db.Aspnetusers.Where(x => x.FullName == salesman).Select(x => x.Id).SingleOrDefault();
                    for (var month = start.Month; month <= end.Month; month++)
                    {
                        var one = _db.Target.Where(x => x.SalesmanId == userId && x.Date.Value.Month == month)
                                    .Select(x => x.Visits).SingleOrDefault();
                        if (one != null)
                        {
                            if (one != 0)
                            {
                                result.Add(Convert.ToDouble(one));
                            }
                            else { result.Add(0); }
                        }
                        else
                        {
                            Console.WriteLine("No Sales Target detected");
                            return null;
                        }

                    }


                    return result;
                }
                else if (period == "annual")
                {
                    List<Double> result = new List<double>();
                    var userId = _db.Aspnetusers.Where(x => x.FullName == salesman).Select(x => x.Id).SingleOrDefault();
                    for (var year = start.Year; year <= end.Year; year++)
                    {
                        var one = _db.Target.Where(x => x.SalesmanId == userId && x.Date.Value.Year == year)
                                    .Select(x => x.Visits).SingleOrDefault();
                        if (one != 0 && one != null)
                        {

                            result.Add(Convert.ToDouble(one));
                        }
                        else
                        {
                            Console.WriteLine("No Sales Target detected");
                            return null;
                        }

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
        public async Task<int> UpdateTarget(int id, Target target)
        {
            if (_db != null)
            {
                Target existItem = _db.Target.Where(f => f.Idtarget == id).FirstOrDefault();
                if (existItem != null)
                {
                    existItem.Idtarget = target.Idtarget;
                    existItem.SalesmanId = target.SalesmanId;
                    existItem.Visits = target.Visits;
                    existItem.Sales = target.Sales;

                }

                _db.Target.Update(existItem);
                await _db.SaveChangesAsync();
                return 1;
            }
            return 0;
        }
        public Double GetSalesbySalesmanByMonth(string salesman, int? month, int? year)
        {

            {
                try
                {
                    if (year == null)
                    {
                        Double result = 0;
                        var userId = _db.Aspnetusers.Where(x => x.FullName == salesman).Select(x => x.Id).SingleOrDefault();
                        List<int> invoices = _db.Invoice
                                .Where(x => x.UserId == userId && x.Date.Value.Month == month)
                                .Select(x => x.Idinvoice).ToList();
                        foreach (var item in invoices)
                        {
                            result++;
                        }
                        return result;
                    }
                    else if (month == null)
                    {
                        Double result = 0;
                        var userId = _db.Aspnetusers.Where(x => x.FullName == salesman).Select(x => x.Id).SingleOrDefault();

                        List<int> invoices = _db.Invoice
                                .Where(x => x.UserId == userId && x.Date.Value.Year == year)
                                .Select(x => x.Idinvoice).ToList();
                        foreach (var item in invoices)
                        {
                            result++;
                        }

                        return result;
                    }

                    return 0;
                }
                catch (Exception)
                {

                    return 0;
                }
            }
        }
        public Double GetSalesTargetByMonth(string salesman, int? month, int? year)
        {
            try
            {
                if (year == null)
                {
                    //Define list of sales to store the result
                    Double result = 0;
                    var userId = _db.Aspnetusers.Where(x => x.FullName == salesman).Select(x => x.Id).SingleOrDefault();
                    var one = _db.Target.Where(x => x.SalesmanId == userId && x.Date.Value.Month == month)
                                    .Select(x => x.Sales).SingleOrDefault();
                    if (one != null)
                    {
                        if (one != 0)
                        {
                            result = Convert.ToDouble(one);
                        }
                        else { result = 0; }
                    }

                    else
                    {
                        Console.WriteLine("No Sales Target detected");
                        return 0;
                    }

                    return result;
                }

                else if (month == null)
                {
                    Double result = 0;
                    var userId = _db.Aspnetusers.Where(x => x.FullName == salesman).Select(x => x.Id).SingleOrDefault();
                    var salesTarget = _db.Target.Where(x => x.SalesmanId == userId && x.Date.Value.Year == year)
                                    .Select(x => x.Sales).ToList();
                    foreach (var item in salesTarget)
                    {
                        result += Convert.ToDouble(item.Value);
                    }
                    //if (one != null)
                    //{
                    //    if (one != 0)
                    //    {

                    //        result = Convert.ToDouble(one);
                    //    }
                    //    else { result = 0; }
                    //}
                    //else
                    //{
                    //    Console.WriteLine("No Sales Target detected");
                    //    return 0;
                    //}
                    return result;
                }

                return 0;
            }
            catch (Exception)
            {

                return 0;
            }
        }
        public Double GetVisitTartgetByMonth(string salesman, int? month, int? year)
        {
            try
            {
                if (year == null)
                {
                    Double result = 0;
                    var userId = _db.Aspnetusers.Where(x => x.FullName == salesman).Select(x => x.Id).SingleOrDefault();

                    var one = _db.Target.Where(x => x.SalesmanId == userId && x.Date.Value.Month == month)
                                .Select(x => x.Visits).SingleOrDefault();
                    if (one != null)
                    {
                        if (one != 0)
                        {
                            result = Convert.ToDouble(one);
                        }
                        else { result = 0; }
                    }
                    else
                    {
                        Console.WriteLine("No Sales Target detected");
                        return 0;
                    }
                    return result;
                }
                else if (month == null)
                {
                    Double result = 0;
                    var userId = _db.Aspnetusers.Where(x => x.FullName == salesman).Select(x => x.Id).SingleOrDefault();
                    var visitTarget = _db.Target.Where(x => x.SalesmanId == userId && x.Date.Value.Year == year)
                                    .Select(x => x.Visits).ToList();
                    foreach (var item in visitTarget)
                    {
                        result += Convert.ToDouble(item.Value);
                    }
                    //if (one != null)
                    //{
                    //    if (one != 0)
                    //    {

                    //        result = Convert.ToDouble(one);
                    //    }
                    //    else { result = 0; }
                    //}
                    //else
                    //{
                    //    Console.WriteLine("No Sales Target detected");
                    //    return 0;
                    //}
                    return result;
                }
                return 0;
            }
            catch (Exception)
            {

                return 0;
            }
        }
        public List<(Double, Double)> EvaluateSalesman(string salesman, string period, DateTime start, DateTime end)
        {
            try
            {
                if (period == "monthly")
                {
                    List<Double> Evaluation = new List<double>();
                    //Evaluate Visits
                    TargetViewModel n = new TargetViewModel();
                    List<(Double, Double)> result = new List<(Double, Double)>();

                    VisitServices visitServices = new VisitServices(_db);

                    var userId = _db.Aspnetusers.Where(x => x.FullName == salesman).Select(x => x.Id).SingleOrDefault();
                    for (var month = start.Month; month <= end.Month; month++)
                    {
                        var resultVisits = visitServices.GetVistisBySalesmanByMonth(salesman, month, null);
                        var target = GetVisitTartgetByMonth(salesman, month, null);
                        if (target != 0)
                        {
                            n.Visits = (resultVisits * 100) / target;

                        }

                        else
                        {
                            Console.WriteLine("No Visit Target detected");
                            return null;

                        }
                        //Evaluate Sales
                        List<double> resultSales = new List<double>();
                        var Sales = GetSalesbySalesmanByMonth(salesman, month, null);
                        var Salestarget = GetSalesTargetByMonth(salesman, month, null);
                        if (Salestarget != 0)
                        {
                            n.Sales = (Sales * 100) / Salestarget;

                        }
                        else
                        {
                            Console.WriteLine("No Sales Target detected");
                            return null;
                        }
                        var vis = Convert.ToDouble(n.Visits);
                        var sal = Convert.ToDouble(n.Sales);
                        result.Add((vis, sal));
                    }

                    return result;
                }
                else if (period == "annual")
                {
                    List<Double> Evaluation = new List<double>();
                    //Evaluate Visits
                    TargetViewModel n = new TargetViewModel();
                    List<(Double, Double)> result = new List<(Double, Double)>();
                    
                    VisitServices visitServices = new VisitServices(_db);
                    var userId = _db.Aspnetusers.Where(x => x.FullName == salesman).Select(x => x.Id).SingleOrDefault();
                    for (var year = start.Year; year <= end.Year; year++)
                    {
                        var resultVisits = visitServices.GetVistisBySalesmanByMonth(salesman, null, year);
                        var target = GetVisitTartgetByMonth(salesman, null, year);

                        if (target != 0)
                        {
                            n.Visits = (resultVisits * 100) / target;

                        }

                        else
                        {
                            Console.WriteLine("No Visit Target detected");
                            return null;

                        }
                        //Evaluate Sales
                        List<double> resultSales = new List<double>();
                        var Sales = GetSalesbySalesmanByMonth(salesman, null, year);
                        var Salestarget = GetSalesTargetByMonth(salesman, null, year);
                        if (Salestarget != 0)
                        {
                            n.Sales = (Sales * 100) / Salestarget;

                        }
                        else
                        {
                            Console.WriteLine("No Sales Target detected");
                            return null;
                        }
                        var vis = Convert.ToDouble(n.Visits);
                        var sal = Convert.ToDouble(n.Sales);
                        result.Add((vis, sal));
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


        //public List<Double> GetSalesbySalesman(string salesman, string period, DateTime start, DateTime end)
        //{
        //    if (_db != null)
        //    {
        //        try
        //        {
        //            if (period == "monthly")
        //            {
        //                List<Double> result = new List<double>();
        //                Double value = 0;
        //                var userId = _db.Aspnetusers.Where(x => x.FullName == salesman).Select(x => x.Id).SingleOrDefault();
        //                //get items from invoice table according to salesman_id
        //                for (int month = start.Month; month <= end.Month; month++)
        //                {

        //                    List<int> invoices = _db.Invoice
        //                        .Where(x => x.UserId == userId && x.Date.Value.Month == month)
        //                        .Select(x => x.Idinvoice).ToList();
        //                    foreach (var item in invoices)
        //                    {
        //                        value++;
        //                    }
        //                    result.Add(value);
        //                }

        //                return result;
        //            }
        //            else if (period == "annual")
        //            {
        //                List<Double> result = new List<double>();
        //                Double value = 0;
        //                var userId = _db.Aspnetusers.Where(x => x.FullName == salesman).Select(x => x.Id).SingleOrDefault();
        //                //get items from invoice table according to salesman_id
        //                for (int year = start.Year; year < end.Year; year++)
        //                {
        //                    List<int> invoices = _db.Invoice
        //                        .Where(x => x.UserId == userId && x.Date.Value.Year == year)
        //                        .Select(x => x.Idinvoice).ToList();
        //                    foreach (var item in invoices)
        //                    {
        //                        value++;
        //                    }
        //                    result.Add(value);
        //                }

        //                return result;
        //            }

        //        }
        //        catch (Exception)
        //        {
        //            return null;
        //        }
        //    }
        //    return null;
        //}


        //public List<Double> GetSalesTarget(string salesman, string period, DateTime start, DateTime end)
        //{
        //    try
        //    {
        //        if (period == "monthly")
        //        {
        //            //Define list of sales to store the result
        //            List<Double> result = new List<double>();
        //            var userId = _db.Aspnetusers.Where(x => x.FullName == salesman).Select(x => x.Id).SingleOrDefault();
        //            for (var month = start.Month; month <= end.Month; month++)
        //            {
        //                var one = _db.Target.Where(x => x.SalesmanId == userId && x.Date.Value.Month == month)
        //                            .Select(x => x.Sales).SingleOrDefault();
        //                if (one != null)
        //                {
        //                    if (one != 0)
        //                    {
        //                        result.Add(Convert.ToDouble(one));
        //                    }
        //                    else { result.Add(0); }
        //                }

        //                else
        //                {
        //                    Console.WriteLine("No Sales Target detected");
        //                    return null;
        //                }
        //            }


        //            return result;
        //        }
        //        else if (period == "annual")
        //        {
        //            List<Double> result = new List<double>();
        //            var userId = _db.Aspnetusers.Where(x => x.FullName == salesman).Select(x => x.Id).SingleOrDefault();
        //            for (var year = start.Year; year <= end.Year; year++)
        //            {
        //                var one = _db.Target.Where(x => x.SalesmanId == userId && x.Date.Value.Year == year)
        //                            .Select(x => x.Sales).SingleOrDefault();
        //                if (one != 0 && one != null)
        //                {

        //                    result.Add(Convert.ToDouble(one));
        //                }
        //                else
        //                {
        //                    Console.WriteLine("No Sales Target detected");
        //                    return null;
        //                }
        //            }
        //            return result;
        //        }

        //        return null;
        //    }
        //    catch (Exception)
        //    {

        //        return null;
        //    }
        //}
    }
}
