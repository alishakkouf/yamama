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
        Task<Invoice> AddImportInvoceAsync(InvoiceCartViewModel impoInvoice);


        //.................Report for import  for all product................
         Task<List<Double>> GetImportedReports(string period , DateTime from, DateTime to, string invoType);
        
        ///........Report for Import based on product type ...........
        ///

        Task<List<(string, double)>> GetProductImportedReports(string period, DateTime from, DateTime to, string name , string invoType);
        

       
    };
}
