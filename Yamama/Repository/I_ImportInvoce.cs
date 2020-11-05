using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yamama.ViewModels;
namespace Yamama.Repository
{
    public  interface I_ImportInvoce
    {
       

        //Add import invoice
        Task<Invoice> AddImportInvoceAsync(ImportCartInvoiceViewModel impoInvoice);


        //.................Report for import  for all product................


        Task<List<Double>> GetImportedReports(string period , DateTime from, DateTime to);

   


        ///........Report for Import based on product type ...........
        ///

        Task<List<Double>> GetProductImportedReports(string period, DateTime from, DateTime to, int id );




        //Task<List<Double>> GetDailyTypeImported(DateTime from /*, DateTime to*/, int id);

        //Task<List<Double>> GetMonthlyTypeImported(DateTime from, DateTime to, int id);

        //Task<List<Double>> GetAnnualTypeImported(DateTime from, DateTime to, int id);

        //Task<List<Double>> GetDailyImported(DateTime from /*, DateTime to*/);

        //Task<List<Double>> GetMonthlyImported(DateTime from, DateTime to);

        //Task<List<Double>> GetAnnualImported(DateTime from, DateTime to);
    };
}
