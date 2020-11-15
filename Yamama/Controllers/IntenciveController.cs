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
    public class IntenciveController : ControllerBase
    {
        private readonly IIntencive _intencive;
        private readonly yamamadbContext _db;

        public IntenciveController(IIntencive intencive, yamamadbContext db)
        {
            _intencive = intencive;
            _db = db;
        }



        //Get Daily Actual Intencive By User
        // GET: api/IntenciveController>
        [HttpGet] 
        [Route("GetDailyActualIntencive")]
        public async Task<IActionResult> GetDailyActualIntencive(int id)
            {
                try
                {

                    var result = await _intencive.GetDailyActualIntencive(id);
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

        //Get Daily Expected Intencive By User
        // GET: api/<IntenciveController>
        [HttpGet]
        [Route("GetDailyExpectedIntencive")]
        public async Task<IActionResult> GetDailyExpectedIntencive(int id)
            {
                try
                {

                    var result = await _intencive.GetDailyExpectedIntencive(id);
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

        // GET: api/<IntenciveController>
        [HttpGet]
        [Route("GetExpectedIntenciveByUser")]
        public async Task<IActionResult> GetExpectedIntenciveByUser(string user, string period, DateTime start, DateTime end)
            {
                try
                {

                    var result = await _intencive.GetExpectedIntenciveByUser(user, period, start, end);
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

        // GET: api/<IntenciveController>
        [HttpGet]
        [Route("GetActaulIntenciveByUser")]
         public async Task<IActionResult> GetActaulIntenciveByUser(string user, string period, DateTime start, DateTime end)
            {
                try
                {

                    var result = await _intencive.GetActualIntenciveByUser(user, period, start, end);
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

        // POST api/<IntenciveController>
        [HttpPost]
        [Route("AddActualIntencive")]
        public async Task<IActionResult> AddActualIntencive([FromBody] ActualIntencive actual)
            {
                try
                {

                    var result = await _intencive.AddActualIntencive(actual);
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

        // POST api/<IntenciveController>
        [HttpPost]
        [Route("AddExpectedIntencive")]
        public async Task<IActionResult> AddExpectedIntencive([FromBody] ExpectedIntencive expected)
            {
                try
                {

                    var result = await _intencive.AddExpectedIntencive(expected);
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

        // PUT api/<IntenciveController>/
        [HttpPut]
        [Route("UpdateActualIntencive/{id}")]
        public async Task<IActionResult> UpdateActualIntencive(ActualIntencive actual, int id)
            {
                try
                {
                    var result = await _intencive.UpdateActualIntencive(id, actual);

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

        // PUT api/<IntenciveController>/
        [HttpPut("UpdateExpectedIntencive/{id}")]

       public async Task<IActionResult> UpdateExpectedIntencive(ExpectedIntencive expected, int id)
            {
                try
                {
                    var result = await _intencive.UpdateExpectedIntencive(id, expected);

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

        // DELETE api/IntenciveController>/
        [HttpDelete]
        [Route("DeleteActualIntencive/{id}")]
        public async Task<IActionResult> DeleteActualIntencive(int id)
            {
                try
                {
                    var result = await _intencive.DeleteActualIntencive(id);


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

        // DELETE api/<IntenciveController>/
        [HttpDelete]
        [Route("DeleteExpectedIntencive/{id}")]
         public async Task<IActionResult> DeleteExpectedIntencive(int id)
            {
                try
                {
                    var result = await _intencive.DeleteExpectedIntencive(id);


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
