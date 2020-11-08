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
    public class ProductionByTypeController : ControllerBase
    {
        private readonly IProductionByType _prod;
        private readonly yamamadbContext _db;

        public ProductionByTypeController(IProductionByType prod, yamamadbContext db)
        {
            _prod = prod;
            _db = db;
        }
        // POST api/<ProductionByTypeController>
        [HttpPost]
        [Route("AddProduction")]
        public async Task<IActionResult> AddProduction([FromBody] Production prod)
        {
            try
            {

                var result = await _prod.AddProduction(prod);
                if (result != 0)
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

            catch
            {
                return BadRequest();
            }
        }

        // PUT api/<ProductionByTypeController>/
        [HttpPut]
        [Route("UpdateProd/{id}")]

        public async Task<IActionResult> UpdateProd(int id, Production prod )
        {
            try
            {
                var result = await _prod.UpdateProd(id, prod);

                if (result != 0)
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

            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/ProductionByTypeController>/
        [HttpDelete]
        [Route("DeleteProd/{id}")]
        public async Task<IActionResult> DeleteProd(int id)
        {
            try
            {
                var result = await _prod.DeleteProd(id);


                if (result != 0)
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

            catch
            {
                return BadRequest();
            }

        }


        //Get Daily Production by Prodution ID
        // GET: api/<ProductionByTypeController>
        [HttpGet]
        [Route("GetDailyProd/{id}")]
        public async Task<IActionResult> GetDailyProd(int id)
        {
            try
            {

                var result = await _prod.GetDailyProd(id);
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
            catch
            {
                return BadRequest();
            }
        }


        //Get All Daily Production By type
        // GET: api/<ProductionByTypeController>
        [HttpGet]
        [Route("GetAllDailyProd")]
        public async Task<IActionResult> GetAllDailyProd(int type)
        {
            try
            {

                var result = await _prod.GetAllDailyProd(type);
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
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/<ProductionByTypeController>
        [HttpGet]
        [Route("GetProductionReports")]
        public async Task<IActionResult> GetProductionReports(int type,string period,DateTime start, DateTime end)
        {
            try
            {

                var result = await _prod.GetProductionReports(type,period,start,end);
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
            catch
            {
                return BadRequest();
            }
        }
    }
}