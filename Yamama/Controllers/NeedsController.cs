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
    public class NeedsController : ControllerBase
    {
        private readonly INeeds _needs;
        private readonly yamamadbContext _db;

        public NeedsController(INeeds needs, yamamadbContext db)
        {
            _needs = needs;
            _db = db;
        }



        //Get Daily Actual Needs By type
        // GET: api/<NeedsController>
        [HttpGet]
        [Route("GetDailyActualNeeds")]
        public async Task<IActionResult> GetDailyActualNeeds(int id)
        {
            try
            {

                var result = await _needs.GetDailyActualNeeds(id);
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

        //Get Daily Expected Needs By type
        // GET: api/<NeedsController>
        [HttpGet]
        [Route("GetAllDailyExpectedNeeds")]
        public async Task<IActionResult> GetAllDailyExpectedNeeds(int type)
        {
            try
            {

                var result = await _needs.GetDailyExpectedNeeds(type);
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

        // GET: api/<NeedsController>
        [HttpGet]
        [Route("GetExpectedNeedsByType")]
        public async Task<IActionResult> GetExpectedNeedsByType(int type, string period, DateTime start, DateTime end)
        {
            try
            {

                var result = await _needs.GetExpectedNeedsByType(type, period, start, end);
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

        // GET: api/<NeedsController>
        [HttpGet]
        [Route("GetActaulNeedsByType")]
        public async Task<IActionResult> GetActaulNeedsByType(int type, string period, DateTime start, DateTime end)
        {
            try
            {

                var result = await _needs.GetActualNeedsByType(type, period, start, end);
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

        // POST api/<NeedsController>
        [HttpPost]
        [Route("AddActualNeeds")]
        public async Task<IActionResult> AddActualNeeds([FromBody] ActualNeeds actual)
        {
            try
            {

                var result = await _needs.AddActualNeeds(actual);
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

        // POST api/<NeedsController>
        [HttpPost]
        [Route("AddExpectedNeeds")]
        public async Task<IActionResult> AddExpectedNeeds([FromBody] ExpectedNeeds expected)
        {
            try
            {

                var result = await _needs.AddExpectedNeeds(expected);
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

        // PUT api/<NeedsController>/
        [HttpPut]
        [Route("UpdateActualNeeds")]

        public async Task<IActionResult> UpdateActualNeeds(ActualNeeds actual, int id)
        {
            try
            {
                var result = await _needs.UpdateActualNeeds(id, actual);

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

        // PUT api/<NeedsController>/
        [HttpPut]
        [Route("UpdateExpectedNeeds")]
        public async Task<IActionResult> UpdateExpectedNeeds(ExpectedNeeds expected, int id)
        {
            try
            {
                var result = await _needs.UpdateExpectedNeeds(id, expected);

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

        // DELETE api/<NeedsController>/
        [HttpDelete]
        [Route("DeleteActualNeeds")]
        public async Task<IActionResult> DeleteActualNeeds(int id)
        {
            try
            {
                var result = await _needs.DeleteActualNeeds(id);


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

        // DELETE api/<NeedsController>/
        [HttpDelete]
        [Route("DeleteExpectedNeeds/{id}")]
        public async Task<IActionResult> DeleteExpectedNeeds(int id)
        {
            try
            {
                var result = await _needs.DeleteExpectedNeeds(id);


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
    }
}
