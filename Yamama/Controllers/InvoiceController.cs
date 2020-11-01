﻿using System;
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

        public InvoiceController(IInvoicecs invoice)
        {
            _invoice = invoice;
        }

        //POST api/<InvoiceController>
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        [Route("Create")]
        public async Task<IActionResult> Create(InvoiceCartViewModel invoiceCartViewModel)
        {

            Invoice result = await _invoice.AddInvoiceAsync(invoiceCartViewModel);
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

        //getInvoiceDetailes


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
        [HttpPost]
        //[Authorize(Roles = "Admin  , Employee")]
        [Route("ClientInvoiceDetailes")]
        public async Task<IActionResult> ClientInvoiceDetailes(int FactoryId, int ProjectId)
        {

          List<Invoice> result = await _invoice.GetInvoiceDetailesForClient(FactoryId, ProjectId);
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
        public async Task<IActionResult> TansportReport(int transporter, int FactoryId, int ProjectId, int product)
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
    }
}