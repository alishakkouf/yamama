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
    public class RequestInformationController : ControllerBase
    {
        private readonly IRequestInformation _requestInfo;
        private readonly yamamaContext _db;

        public RequestInformationController(IRequestInformation requestInfo, yamamaContext db)
        {
            _requestInfo = requestInfo;
            _db = db;
        }


        // POST api/<RequestInformationController>
        [HttpPost("AddRequestInfo")]
        public async Task<IActionResult> AddRequestInfo([FromBody] TaskTypeViewModel taskTypeViewModel)
        {
            try
            {

                var result = await _requestInfo.AddRequestInfo(taskTypeViewModel);
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

        // GET: api/<RequestInformationController>
        [HttpGet("ArchiveRequestInfo")]
        public async Task<IActionResult> ArchiveRequestInfo()
        {
            try
            {
                var result = await _db.RequestInformation.ToListAsync();

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

        // GET: api/<RequestInformationController>
        [HttpGet("GetAllRequestInfo")]
        public async Task<IActionResult> GetAllRequestInfo()
        {
            try
            {
                var result = await _requestInfo.GetAllRequestInfo();
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

        // GET: api/<RequestInformationController>
        [HttpGet("NewAssignedRequestInfo")]
        public async Task<IActionResult> NewAssignedRequestInfo()
        {
            try
            {
                var result = await _requestInfo.NewAssignedRequestInfo();
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


        // GET api/<RequestInformationController>/
        [HttpGet("GetRequestInfo/{id}")]
        public async Task<IActionResult> GetRequest(int id)
        {
            try
            {
                
                var result = await _requestInfo.GetRequest(id);
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
        // PUT api/<RequestInformationController>/
        [HttpPut("UpdateRequestInfo/{id}")]

        public async Task<IActionResult> UpdateRequestInfo(int id,[FromBody] TaskTypeViewModel taskTypeViewModel)
        {
            try
            {
                var result = await _requestInfo.UpdateRequestInfo(id, taskTypeViewModel);

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

        // DELETE api/<RequestInformationController>/
        [HttpDelete("DeleteRequestInfo/{id}")]
        public async Task<IActionResult> DeleteRequestInfo(int id)
        {
            try
            {
                var result = await _requestInfo.DeleteRequestInfo(id);


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
