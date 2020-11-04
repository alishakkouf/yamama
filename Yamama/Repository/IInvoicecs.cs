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

        Task<Invoice> GetInvoice(int IdInvoice);

        Task<Invoice> AddInvoiceAsync(InvoiceCartViewModel invoiceCart);

        Task<int> DeleteInvoiceAsync(int IdInvoice);

        Task<InvoiceCartViewModel> getInvoiceDetailes(int invoiceId);

        Task<List<Invoice>> GetInvoiceDetailesForClient(int FactoryId, int ProjectId);

        Task<List<Double>> GetSalesReports(string period, DateTime start, DateTime end);

        Task<List<MoneyAndQuantity>> GetSalesReportsClientCement(int factory,int project , string CementType , string period , DateTime from , DateTime end);

        Task<List<TransporterReports>> GetReportsAsync(int transporter, int FactoryId, int ProjectId, int product);

        Task<List<CustomerMoneyAccountsViewModel>> GetCustomersMoneyReportsAsync(int FactoryId, int ProjectId);

        Task<List<(string, Double)>> IndebtednessReportsAsync();

        Task<LateCustomersViewModel> GetLateCustomers();


    }
}
