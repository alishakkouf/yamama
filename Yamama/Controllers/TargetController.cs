using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yamama.Models;
using Yamama.Repository;
using Yamama.ViewModels;

namespace Yamama.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TargetController : ControllerBase
    {
        private readonly ITarget _target;
        private readonly yamamadbContext _db;

        public TargetController(ITarget target, yamamadbContext db)
        {
            _target = target;
            _db = db;
        }

        // POST api/<TargetController>
        [HttpPost]
        [Route("AddTarget")]
        public async Task<IActionResult> AddTarget(Target target)
        {
            try
            {

                var result = await _target.AddTarget(target);
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
        
        // PUT api/<TargetController>/
        [HttpPut]
        [Route("UpdateTarget/{id}")]
        public async Task<IActionResult> UpdateTarget(int id, Target target)
        {
            try
            {
                var result = await _target.UpdateTarget(id, target);

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

        // DELETE api/TargetController>/
        [HttpDelete]
        [Route("DeleteTarget/{id}")]
        public async Task<IActionResult> DeleteTarget(int id)
        {
            try
            {
                var result = await _target.DeleteTarget(id);


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

        // GET api/<TargetController>/
        [HttpGet]
        [Route("EvaluateSalesman")]
        public IActionResult EvaluateSalesman(int salesman, string period, DateTime start, DateTime end)
        {
            try
            {
                var result =  _target.EvaluateSalesman(salesman, period, start, end);
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
