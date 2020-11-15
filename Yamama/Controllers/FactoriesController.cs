using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using Yamama.Models;
using Yamama.Repository;
using Yamama.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Yamama.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactoriesController : ControllerBase
    {

        //inject the repositories and dbcontext class

        private readonly IFactory _factory;
        private readonly yamamadbContext _db;
        public FactoriesController(IFactory factory, yamamadbContext db)
        {
            _factory = factory;
            _db = db;
        }

        // GET: api/<FactoriesController>
        [HttpGet]
        [Route("getfactories")]
        public async Task<IActionResult> getfactories()
        {
            try
            {
                var factory = await  _factory.GetFactories();
                if (factory == null)
                {
                    ResponseViewModel Response1 = new ResponseViewModel(false, HttpStatusCode.NoContent, "NoContent", null);
                    return Ok(Response1);
                }

                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", factory);
                return Ok(Response);
               
            }
            catch(Exception)
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.BadRequest, "failed", null);
                return Ok(Response);
            }
        }

        // GET api/<FactoriesController>/5
        [HttpGet]
        [Route("getfactory")]
        public async  Task<IActionResult> getfactory( int id)
        {
            try
            {
               var factory =  await  _factory.GetFactory(id);
                if (factory == null)
                {
                    ResponseViewModel Response1 = new ResponseViewModel(false, HttpStatusCode.NoContent, "NoContent", null);
                    return Ok(Response1);
                }
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", factory);
                return Ok(Response);
            }
            catch (Exception)
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.BadRequest, "failed", null);
                return Ok(Response);
            }

        }
        // POST api/<FactoriesController>
        [HttpPost]
        [Route("addfactory")]
        public async Task <IActionResult> addfactory(Factory factory)
        {
            try
            {
               await _factory.AddFactoryAsync(factory);
               
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", factory);
                return Ok(Response);
                
            }

            catch (Exception)
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.NoContent, "failed", null);
                return Ok(Response);
            }
        }
           
      
        // PUT api/<FactoriesController>/5
        [HttpPut]
        [Route("updatefactory")]
        public async Task<IActionResult> updatefactory(Factory factory , int id )
        {
            try
            {
                await  _factory.UpdateFactory(id, factory);
             
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", factory);
                return Ok(Response);
            }

            catch (Exception)
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.NoContent, "failed", null);
                return Ok(Response);
            }
        }

        // DELETE api/<FactoriesController>/5
        [HttpDelete]
        [Route("deletefactory")]
        public async Task<ActionResult> deletefactory( int id)
        {
    
            var factory = await _factory.DeleteFactoryAsync(id);
            if (factory == 0)
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


