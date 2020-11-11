using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using Yamama.Models;
using Yamama.Repository;
using Yamama.ViewModels;

namespace Yamama.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertController : ControllerBase
    {
        private readonly IAlert _alert;
        private readonly yamamadbContext _db;

        public AlertController(IAlert alert, yamamadbContext db)
        {
            _alert = alert;
            _db = db;
        }


        // POST api/<AlertController>
        [HttpPost]
        [Route("AddAlert")]
        public async Task<IActionResult> AddAlert([FromBody] Alert taskTypeViewModel)
        {
            try
            {

                var result = await _alert.AddAlert(taskTypeViewModel);
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

        // GET: api/<AlertController>
        [HttpGet]
        [Route("ArchiveAlert")]
        public async Task<IActionResult> ArchiveAlert()
        {
            try
            {
                var result = await _alert.ArchiveAlert();

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

        // GET: api/<AlertController>
        [HttpGet]
        [Route("GetAllAlerts")]
        public async Task<IActionResult> GetAllAlerts()
        {
            try
            {
                var result = await _alert.GetAllAlerts();
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

        // GET: api/<AlertController>
        [HttpGet]
        [Route("NewAssignedAlerts")]
        public async Task<IActionResult> NewAssignedAlerts()
        {
            try
            {
                var result = await _alert.NewAssignedAlerts();
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


        // GET api/<AlertController>/
        [HttpGet]
        [Route("GetAlert")]
        public async Task<IActionResult> GetAlert(int id)
        {
            try
            {
                
                var result = await _alert.GetAlert(id);
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
        // PUT api/<AlertController>/
        [HttpPut]
        [Route("UpdateAlert")]

        public async Task<IActionResult> UpdateAlert(Alert taskTypeViewModel, int id)
        {
            try
            {
                var result = await _alert.UpdateAlert(id, taskTypeViewModel);

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

        // DELETE api/<AlertController>/
        [HttpDelete]
        [Route("DeleteAlert")]
        public async Task<IActionResult> DeleteAlert(int id)
        {
            try
            {
                var result = await _alert.DeleteAlert(id);


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
