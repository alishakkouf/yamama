using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yamama.Models;
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
        [Route("/api/getfactories")]
        public  async Task <ActionResult> GetAll()
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
        [Route("/api/getfactory/{id}")]

        public async  Task<ActionResult<Factory>> GetFactory( int id)
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
        [Route("/api/addfactory")]
        public async Task <ActionResult> Add (Factory factory)
        {
            try
            {
               await _factory.AddFactoryAsync(factory);
                await _db.SaveChangesAsync();
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
        [Route("/api/updatefactory/{id}")]
        public async Task <ActionResult> Update(Factory factory , int id )
        {
            try
            {
               await  _factory.UpdateFactory(id, factory);
                await _db.SaveChangesAsync();
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
        [Route("/api/deletefactory/{id}")]
        public async Task  <ActionResult> Delete( int id)
        {
    
            var factory = await _factory.GetFactory(id);
            if (factory == null)
            {
                var Response1 = new ResponseViewModel(false, HttpStatusCode.NoContent, "failed", null);
                return Ok(Response1);
            }
                  await  _factory.DeleteFactoryAsync(id);
            var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", null);
            return Ok(Response);
        }

    }
}


