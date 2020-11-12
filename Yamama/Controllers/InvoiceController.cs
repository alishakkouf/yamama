using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yamama.Repository;
using Yamama.ViewModels;

namespace Yamama.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoicecs _invoice;
        private readonly ICart _cart;

        public InvoiceController(IInvoicecs invoice , ICart cart)
        {
            _invoice = invoice;
            _cart = cart;
        }

        //POST api/<InvoiceController>
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        [Route("Create")]
        public async Task<IActionResult> Create(InvoiceCartViewModel invoiceCartViewModel)
        {

            var result = await _invoice.AddInvoiceAsync(invoiceCartViewModel);
            if (result != null)
            {
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", result);
                return Ok(Response);
            }
            else
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.NoContent, "failed", null);
                return Ok(Response);
            }




        }

        //POST api/<InvoiceController>
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        [Route("GetInvoice")]
        public async Task<IActionResult> GetInvoice(int id)
        {

            InvoiceViewModel result = await _invoice.GetInvoice(id);
            if (result != null)
            {
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", result);
                return Ok(Response);
            }
            else
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.NoContent, "failed", null);
                return Ok(Response);
            }




        }


        //POST api/<InvoiceController>
        [HttpGet]
        //[Authorize(Roles = "Admin  , Employee")]
        [Route("InvoiceDetailes")]
        public async Task<IActionResult> InvoiceDetailes(int invoiceId)
        {

            InvoiceCartViewModel result = await _invoice.getInvoiceDetailes(invoiceId);
            if (result != null)
            {
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", result);
                return Ok(Response);
            }
            else
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.NoContent, "failed", null);
                return Ok(Response);
            }




        }


        //POST api/<InvoiceController>
        [HttpGet]
        //[Authorize(Roles = "Admin  , Employee")]
        [Route("ClientInvoiceDetailes")]
        public async Task<IActionResult> ClientInvoiceDetailes(string FactoryId, string ProjectId)
        {

          List<InvoiceViewModel> result = await _invoice.GetInvoiceDetailesForClient(FactoryId, ProjectId);
            if (result != null)
            {
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", result);
                return Ok(Response);
            }
            else
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.NoContent, "failed", null);
                return Ok(Response);
            }




        }

        //POST api/<InvoiceController>
        [HttpGet]
        [Route("Sales")]
        public async Task<IActionResult> Sales(string period, DateTime start, DateTime end)
        {

            var result = await _invoice.GetSalesReports(period, start, end);
            if (result != null)
            {
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", result);
                return Ok(Response);
            }
            else
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.NoContent, "failed", null);
                return Ok(Response);
            }




        }


        //POST api/<InvoiceController>
        [HttpGet]
        [Route("CementSales")]
        public async Task<IActionResult> CementSales(int factory, int project, string CementType, string period, DateTime from, DateTime end)
        {

            var result = await _invoice.GetSalesReportsClientCement(factory, project, CementType, period,  from, end);
            if (result != null)
            {
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", result);
                return Ok(Response);
            }
            else
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.NoContent, "failed", null);
                return Ok(Response);
            }




        }

        //POST api/<InvoiceController>
        [HttpGet]
        [Route("TansportReport")]
        public async Task<IActionResult> TansportReport(string transporter, int FactoryId, int ProjectId, string product)
        {
            var result = await _invoice.GetReportsAsync(transporter, FactoryId, ProjectId, product);
            if (result != null)
            {
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", result);
                return Ok(Response);
            }
            else
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.NoContent, "failed", null);
                return Ok(Response);
            }

        }

        
        //POST api/<InvoiceController>
        [HttpGet]
        [Route("GetCustomersMoneyReports")]
        public async Task<IActionResult> GetCustomersMoneyReports( int FactoryId, int ProjectId)
        {
            var result = await _invoice.GetCustomersMoneyReportsAsync(FactoryId, ProjectId);
            if (result != null)
            {
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", result);
                return Ok(Response);
            }
            else
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.NoContent, "failed", null);
                return Ok(Response);
            }

        }

        

        //POST api/<InvoiceController>
        [HttpGet]
        [Route("IndebtednessReportsAsync")]
        public async Task<IActionResult> IndebtednessReportsAsync()
        {
            var result = await _invoice.IndebtednessReportsAsync();
            if (result != null)
            {
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", result);
                return Ok(Response);
            }
            else
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.NoContent, "failed", null);
                return Ok(Response);
            }

        }

     
        //POST api/<InvoiceController>
        [HttpGet]
        [Route("GetLateCustomers")]
        public async Task<IActionResult> GetLateCustomers()
        {
            var result = await _invoice.GetLateCustomers();
            if (result != null)
            {
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", result);
                return Ok(Response);
            }
            else
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.NoContent, "failed", null);
                return Ok(Response);
            }

        }



    }
}