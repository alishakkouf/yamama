using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yamama.Models;
using Yamama.Repository;
using Yamama.ViewModels;

namespace Yamama.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitController : ControllerBase
    {
        private readonly IVisit _visit;
        private readonly yamamadbContext _db;
        

        public VisitController(IVisit visit, yamamadbContext db)
        {
            _visit = visit;
            _db = db;
        }


        // POST api/<VisitController>
        [HttpPost]
        [Route("AddVisit")]
        public async Task<IActionResult> AddVisit([FromBody] TaskTypeViewModel taskTypeViewModel)
        {
            try
            {
                
                var result = await _visit.AddVisit(taskTypeViewModel);
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

        // GET: api/<VisitController>
        [HttpGet]
        [Route("ArchiveVisit")]
        public async Task<IActionResult> ArchiveVisit()
        {
            
            try
            {
                var result = await _visit.ArchiveVisit();

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

        // GET: api/<VisitController>
        [HttpGet]
        [Route("GetAllVisits")]
        public async Task<IActionResult> GetAllVisits()
        {
            try
            {
                var result = await _visit.GetAllVisits();
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

        // GET: api/<VisitController>
        [HttpGet]
        [Route("NewAssignedVisits")]
        public async Task<IActionResult> NewAssignedVisits()
        {
            try
            {
                var result = await _visit.NewAssignedVisits();
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


        // GET api/<VisitController>/
        [HttpGet]
        [Route("GetVisitbyID/{id}")]
        public async Task<IActionResult> GetVisitbyID(int id)
        {

            
            try
            {
                var result = await _visit.GetVisitbyID(id);
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

        // GET api/<VisitController>/
        [HttpGet]
        [Route("GetVisitReports")]
        public async Task<IActionResult> GetVisitReports(int salesman, int? projectId, int? factoryId, string period, DateTime start, DateTime end)
        {


            try
            {
                var result = await _visit.GetVisitReports(salesman, projectId, factoryId, period, start, end);
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
        // GET api/<VisitController>/
        [HttpGet]
        [Route("GetVisisBySalesman")]
        public async Task<IActionResult> GetVisisBySalesman(int salesman, string period, DateTime start, DateTime end)
        {


            try
            {
                var result = await _visit.GetVisisBySalesman(salesman, period, start, end);
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
        // GET api/<VisitController>/
        [HttpGet]
        [Route("GetVisitsByClient")]
        public async Task<IActionResult> GetVisitsByClient(int? projectId, int? factoryId, string period, DateTime start, DateTime end)
        {


            try
            {
                var result = await _visit.GetVisitsByClient(projectId, factoryId, period, start, end);
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
        // PUT api/<VisitController>/
        [HttpPut]
        [Route("UpdateVisit/{id}")]

        public async Task<IActionResult> UpdateVisit(TaskTypeViewModel taskTypeViewModel, int id)
        {
            try
            {
                var result = await _visit.UpdateVisit(id, taskTypeViewModel);
                
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

        // DELETE api/<VisitController>/
        [HttpDelete]
        [Route("DeleteVisit/{id}")]
        public async Task<IActionResult> DeleteVisit(int id)
        {
            try
            {
                var result= await _visit.DeleteVisit(id);


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
