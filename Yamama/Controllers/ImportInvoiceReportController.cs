using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yamama;
using Yamama.Models;
using Yamama.Repository;
using Yamama.ViewModels;

namespace YamamaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportInvoiceReportController : ControllerBase
    {

        private readonly yamamadbContext _db;

        private readonly I_ImportInvoce _report;
        public ImportInvoiceReportController(yamamadbContext db, I_ImportInvoce report)
        {
            _db = db;
            _report = report;
        }

        
        //get  import reports (daily - annual- monthly)
        [HttpGet]
        [Route("/api/getimportreport")]

        public async Task<ActionResult<Invoice>> GetImportedReports( string period , DateTime from, DateTime to)
        {
            try
            {
                var imported = await _report.GetImportedReports(period, from, to);
                if (imported == null)
                {
                    ResponseViewModel Response1 = new ResponseViewModel(false, HttpStatusCode.NoContent, "NoContent", null);
                    return Ok(Response1);
                }
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", imported);
                return Ok(Response);
            }
            catch (Exception)
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.BadRequest, "failed", null);
                return Ok(Response);
            }
        }

        //get  import reports based on product type (daily - annual- monthly)

        [HttpGet]
        [Route("/api/getproductimportreport")]

        public async Task<ActionResult<Invoice>> GetProductImportedReports(string period, DateTime from, DateTime to, int id )
        {
            try
            {
                var imported = await _report.GetProductImportedReports(period, from, to, id );
                if (imported == null)
                {
                    ResponseViewModel Response1 = new ResponseViewModel(false, HttpStatusCode.NoContent, "NoContent", null);
                    return Ok(Response1);
                }
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", imported);
                return Ok(Response);
            }
            catch (Exception)
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.BadRequest, "failed", null);
                return Ok(Response);
            }
        }

    }
}