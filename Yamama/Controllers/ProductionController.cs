using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Yamama.Models;
using Yamama.Repository;
using Yamama.ViewModels;

namespace Yamama.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionController : ControllerBase
    {
        // inject the required dbcontext and interfaces and services
        private readonly yamamadbContext _db;
        private readonly IProduction _production;

        // create a new instance from the injected classes
        public ProductionController(yamamadbContext db, IProduction production)
        {
            _db = db;
            _production = production;
        }

        // POST api/<ProductionController>
        //request to add new production
        [HttpPost]
        [Route("/api/addproduction")]
        public async Task<ActionResult> AddProduction(Production production)
        {
            try
            {
                await _production.AddProductionAsync(production);
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", production);
                return Ok(Response);
            }
            catch (Exception)
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.NoContent, "failed", null);
                return Ok(Response);
            }
        }

        //.........API Controllers for reporting Production reports (daily - montly - annual) .........
   
        [HttpGet]
        [Route("/api/getProductionReports")]

        public async Task<ActionResult<Production>> GetProductionReports(string period, DateTime from, DateTime to)
        {
            try
            {
                var production = await _production.GetProductinReports(period, from ,to);
                if (production == null)
                {
                    ResponseViewModel Response1 = new ResponseViewModel(false, HttpStatusCode.NoContent, "NoContent", null);
                    return Ok(Response1);
                }
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", production);
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
