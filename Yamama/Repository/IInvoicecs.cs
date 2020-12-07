using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yamama.ViewModels;

namespace Yamama.Repository
{
    public interface IInvoicecs
    {
        Task<List<Invoice>> GetInvoicesAsync();

        Task<InvoiceViewModel> GetInvoice(int IdInvoice);

        Task<string> AddInvoiceAsync(InvoiceCartViewModel invoiceCart ,string usrID);

        Task<int> DeleteInvoiceAsync(int IdInvoice);

        Task<InvoiceCartViewModel> getInvoiceDetailes(int invoiceId);

        Task<List<InvoiceViewModel>> GetInvoiceDetailesForClient(string FactoryId, string ProjectId);

        Task<List<(string, Double)>> GetSalesReports(string period, DateTime start, DateTime end);

        Task<List<(string, MoneyAndQuantity)>> GetSalesReportsClientCement(string factory,string project , string CementType , string period , DateTime from , DateTime end);

        Task<List<TransporterReports>> GetReportsAsync(string transporterName, string factory, string project, string productName);

        Task<List<CustomerMoneyAccountsViewModel>> GetCustomersMoneyReportsAsync(string factory, string project);

        Task<List<(string, Double)>> IndebtednessReportsAsync();

        Task<LateCustomersViewModel> GetLateCustomers();


    }
}
