using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
//using Yamama.Models;
using Yamama.Repository;
using Yamama.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Yamama.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProject _project;

        private readonly yamamadbContext _db;
        public ProjectsController(IProject project, yamamadbContext db)
        {
            _db = db;
            _project = project;
        }
        // GET: api/<ProjectsController>
        //method to send get request to get all projects
        [HttpGet]
        [Route("/api/getprojects")]
        public async Task<ActionResult> getprojects()
        {
            try
            {
                var project = await _project.GetProjects();
                //check if the item has value if not  return msg no content
                if (project == null)
                {

                    ResponseViewModel Response1 = new ResponseViewModel(false, HttpStatusCode.NoContent, "NoContent", null);
                    return Ok(Response1);
                }

                //if the item has value  return succes
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", project);
                return Ok(Response);
            }
            //if the operation faild cause of syntax errors or servers errors
            catch (Exception)
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.BadRequest, "failed", null);
                return Ok(Response);
            }
        }

        // GET api/<ProjectsController>/5
        //method to send get request to  get specific project by id 
        [HttpGet]
        [Route("/api/getproject")]
        public async Task <ActionResult<Project>> getproject(int id)
        {
            try
            {
                var project = await _project.GetProject(id);
                //check if the item has value if not  return msg no content
                if (project == null)
                {
                    ResponseViewModel Response1 = new ResponseViewModel(false, HttpStatusCode.NoContent, "NoContent", null);
                    return Ok(Response1);
                }
                //if the item has value  return succes
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", project);
                return Ok(Response);
            }
            //if the operation faild cause of syntax errors or servers errors
            catch (Exception)
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.BadRequest, "failed", null);
                return Ok(Response);
            }

        }
        // POST api/<ProjectsController>
        //method to send post request to add new project
        [HttpPost]
        [Route("/api/addproject")]
        public async Task <IActionResult> addproject(Project project)
        {
            try
            {
                await _project.AddProjectAsync(project);               
                //if the operation succucced return success
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", project);
                return Ok(Response);
            }
            //if the operation faild cause of syntax errors or servers errors
            catch (Exception)
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.BadRequest, "failed", null);
                return Ok(Response);
            }
        }


        // PUT api/<ProjectsController>/5
        //method to send put request to edit specific project by id
        [HttpPut]
        [Route("/api/updateproject")]
        public async Task  <IActionResult> updateproject( Project project , int id)
        {
            try
            {
               await  _project.UpdateProject(id, project);           
                //if the operation succucced return success
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", project);
                return Ok(Response);
            }
            //if the operation faild cause of syntax errors or servers errors
            catch (Exception)
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.NoContent, "Failed", null);
                return Ok(Response);
            }
        }

        // DELETE api/<ProjectsController>/5
        //method to send delete request to remove specific project by id 
        [HttpDelete]
        [Route("/api/deleteproject")]
        public async Task <ActionResult> deleteproject(int id)
        {
            
                var project= await  _project.DeleteProjectAsync(id);
            if (project == 0)
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.NoContent, "failed", null);
                return Ok(Response);
            }
            else
            {
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", null);
                return Ok(Response);
            }
        }
    }
}
