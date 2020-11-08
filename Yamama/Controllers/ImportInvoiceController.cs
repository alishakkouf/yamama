using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yamama;
//using Yamama.Models;
using Yamama.Repository;
using Yamama.ViewModels;

namespace YamamaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportInvoiceController : ControllerBase
    {

        private readonly yamamadbContext _db;

        private readonly I_ImportInvoce i_ImportInvoce;

        private readonly IInvoicecs _invoice;
        public ImportInvoiceController(yamamadbContext db, I_ImportInvoce impoin, IInvoicecs invoice )
        {
            _db = db;
            i_ImportInvoce = impoin;
            _invoice = invoice;
        }

       
        // POST api/<ImportInvoiceController>
        [HttpPost]
        [Route("/api/addimportinvoice")]
        public async Task<ActionResult> AddImportInvoice(ImportCartInvoiceViewModel impoInvoice)
        {
            try
            {
                await i_ImportInvoce.AddImportInvoceAsync(impoInvoice);
                await _db.SaveChangesAsync();              
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", impoInvoice);
                return Ok(Response);
            }

            catch (Exception)
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.NoContent, "failed", null);
                return Ok(Response);
            }
        }

        // GET: api/<InvoicesController>
        [HttpGet]
        [Route("/api/getinvoices")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var invoice = await _invoice.GetInvoicesAsync();
                if (invoice == null)
                {
                    ResponseViewModel Response1 = new ResponseViewModel(false, HttpStatusCode.NoContent, "NoContent", null);
                    return Ok(Response1);
                }

                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", invoice);
                return Ok(Response);

            }
            catch (Exception)
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.BadRequest, "failed", null);
                return Ok(Response);
            }
        }

        // GET api/<InvoicesController>/5
        [HttpGet]
        [Route("/api/getinvoice/{id}")]

        public async Task<ActionResult<Invoice>> GetInvoice(int id)
        {
            try
            {
                var invoice = await _invoice.GetInvoice(id);
                if (invoice == null)
                {
                    ResponseViewModel Response1 = new ResponseViewModel(false, HttpStatusCode.NoContent, "NoContent", null);
                    return Ok(Response1);
                }
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", invoice);
                return Ok(Response);
            }
            catch (Exception)
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.BadRequest, "failed", null);
                return Ok(Response);
            }

        }

        // DELETE api/<InvoicesController>/5
        [HttpDelete]
        [Route("/api/deleteinvoice/{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            var invoice = await _invoice.GetInvoice(id);
            if (invoice == null)
            {
                var Response1 = new ResponseViewModel(false, HttpStatusCode.NoContent, "failed", null);
                return Ok(Response1);
            }
            await _invoice.DeleteInvoiceAsync(id);
            var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", null);
            return Ok(Response);
        }
    }
}

