﻿using System;
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
        private readonly yamamaContext _db;
        //private readonly TaskTypeViewModel _taskTypeViewModel;

        public VisitController(IVisit visit, yamamaContext db)
        {
            _visit = visit;
            _db = db;
            //_taskTypeViewModel = taskTypeViewModel;
        }


        // POST api/<VisitController>
        [HttpPost("AddVisit")]
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
        [HttpGet("ArchiveVisit")]
        public async Task<IActionResult> ArchiveVisit()
        {
            //var result = await _db.Visit.ToListAsync();
            //return result;
            try
            {
                var result = await _db.Visit.ToListAsync();

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
        [HttpGet("GetAllVisits")]
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
        [HttpGet("NewAssignedVisits")]
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
        [HttpGet("VisitReport/{id}")]
        public async Task<IActionResult> VisitReport(int id)
        {

            //try{
            //await _visit.VisitReport(id);
            //return Ok();
            //}
            //catch
            //{
            //    return BadRequest();
            //}
            try
            {
                //await _visit.VisitReport(id);
                //return Ok();
                var result = await _visit.VisitReport(id);
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
        [HttpPut("UpdateVisit/{id}")]

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
        [HttpDelete("DeleteVisit/{id}")]
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
