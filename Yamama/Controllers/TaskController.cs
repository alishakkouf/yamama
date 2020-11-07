using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Yamama.Models;
using Yamama.Repository;
using Yamama.ViewModels;

namespace Yamama.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITask _task;
        private readonly yamamadbContext _db;
       
        public TaskController(ITask task, yamamadbContext db)
        {
            
            _task = task;
            _db = db;
        }



        // POST api/<TaskController>
        [HttpPost]
        [Route("AddTask")]
        
        public async Task<IActionResult> AddTask([FromBody] TaskTypeViewModel taskTypeViewModel)
        {
            try
            {

                
                var result = await _task.AddTask(taskTypeViewModel);
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

        // GET: api/<TaskController>
        [HttpGet]
        [Route("ArchiveTask")]
        public async Task<IActionResult> ArchiveTask()
        {
            try
            {
                var result = await _task.ArchiveTasks();

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

        // GET: api/<TaskController>
        [HttpGet]
        [Route("GetAllTasks")]
        public async Task<IActionResult> GetAllTasks()
        {
            try
            {
                var result = await _task.GetAllTasks();
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

        // GET: api/<TaskController>
        [HttpGet]
        [Route("NewAssignedTasks")]
        public async Task<IActionResult> NewAssignedTasks()
        {
            try
            {
                var result = await _task.NewAssignedTasks();
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

        // GET api/<TaskController>/
        [HttpGet]
        [Route("GetTask/{id}")]
        public async Task<IActionResult> GetTask(int id)
        {
            try
            {
                
                var result = await _task.GetTask(id);
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

        // PUT api/<TaskController>/
        [HttpPut]
        [Route("UpdateTask/{id}")]

        public async Task<IActionResult> UpdateTask(TaskTypeViewModel taskTypeViewModel, int id)
        {
            try
            {
                var result = await _task.UpdateTask(id, taskTypeViewModel);

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

        // DELETE api/<TaskController>/
        [HttpDelete]
        [Route("DeleteTask/{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
                var result = await _task.DeleteTask(id);


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