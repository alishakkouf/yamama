using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yamama.Services
{
    public class ali
    {
        public async Task<List<Double>> GetSalesReports(string period, DateTime start, DateTime end)
        {
            try
            {
                if (period == "daily")
                {
                    //Define list of invoices to store the result
                    List<Double> result = new List<double>();
                    System.TimeSpan diff = end.Subtract(start);
                    for (var day = start.Date; day <= end; day = day.AddDays(1))
                    {
                        //to store the full sales
                        Double value = 0;

                        string test = day.ToString("yyyy-MM-dd");
                        //return list of id_invoices in each day
                        List<int> invoicesNumbers = _yamamadbContext.Invoice.Where(x => x.Date.ToString() == test).Select(x => x.Idinvoice).ToList();

                        for (int j = 0; j < invoicesNumbers.Count; j++)
                        {
                            InvoiceCartViewModel subResult = await getInvoiceDetailes(invoicesNumbers[j]);
                            value += Convert.ToDouble(subResult.invoice.FullCost.Value);

                        }
                        result.Add(value);
                    }


                    return result;
                }
                else if (period == "monthly")
                {
                    //Define list of invoices to store the result
                    List<Double> result = new List<double>();
                    System.TimeSpan diff = end.Subtract(start);
                    for (var month = start.Month; month <= end.Month; month++)
                    {
                        //to store the full sales
                        Double value = 0;

                        //return list of id_invoices in each day
                        List<int> invoicesNumbers = _yamamadbContext.Invoice.Where(x => x.Date.Value.Month == month).Select(x => x.Idinvoice).ToList();

                        for (int j = 0; j < invoicesNumbers.Count; j++)
                        {
                            InvoiceCartViewModel subResult = await getInvoiceDetailes(invoicesNumbers[j]);
                            value += Convert.ToDouble(subResult.invoice.FullCost.Value);

                        }
                        result.Add(value);
                    }


                    return result;
                }
                else if (period == "annual")
                {
                    //Define list of invoices to store the result
                    List<Double> result = new List<double>();
                    System.TimeSpan diff = end.Subtract(start);
                    for (var year = start.Year; year <= end.Year; year++)
                    {
                        //to store the full sales
                        Double value = 0;

                        //return list of id_invoices in each day
                        List<int> invoicesNumbers = _yamamadbContext.Invoice.Where(x => x.Date.Value.Year == year).Select(x => x.Idinvoice).ToList();

                        for (int j = 0; j < invoicesNumbers.Count; j++)
                        {
                            InvoiceCartViewModel subResult = await getInvoiceDetailes(invoicesNumbers[j]);
                            value += Convert.ToDouble(subResult.invoice.FullCost.Value);

                        }
                        result.Add(value);
                    }


                    return result;
                }
                //else if (period == "weekly")
                //{
                //    //Define list of invoices to store the result
                //    List<Double> result = new List<double>();
                //    Double diff = (end - start).TotalDays;

                //    var fromDay = start.DayOfWeek;
                //    if (fromDay <= DayOfWeek.Saturday)
                //    { Double duration = DayOfWeek.Saturday - fromDay;
                //        diff = diff + duration; }
                //    else
                //    { Double duration = DayOfWeek.Saturday - fromDay;
                //        diff = diff + duration; }





                //    for (var year = start.Year; year <= end.Year; year++)
                //    {
                //        //to store the full sales
                //        Double value = 0;

                //        //return list of id_invoices in each day
                //        List<int> invoicesNumbers = _yamamadbContext.Invoice.Where(x => x.Date.Value.Year == year).Select(x => x.Idinvoice).ToList();

                //        for (int j = 0; j < invoicesNumbers.Count; j++)
                //        {
                //            InvoiceCartViewModel subResult = await getInvoiceDetailes(invoicesNumbers[j]);
                //            value += Convert.ToDouble(subResult.invoice.FullCost.Value);

                //        }
                //        result.Add(value);
                //    }


                //    return result;
                //}

                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
