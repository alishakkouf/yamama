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
    public class ProductionController : ControllerBase
    {
        // inject the required dbcontext and interfaces and services
        private readonly yamamadbContext _db;
        private readonly IProduction _production;

        // create a new instance from the injected classes
        public ProductionController(yamamadbContext db, IProduction production)
        {
            _db = db;
            _production = production;
        }



        //request to get specific production detail
        // GET api/<ProductionController>/5
        [HttpGet]
        [Route("/api/getproduction/{id}")]

        public async Task<ActionResult<Production>> GetProduction(int id)
        {
            try
            {
                // call the required function from productionservice 
                var prod = await _production.GetProduction(id);
                //check if the returned has value 
                if (prod == null)
                {
                    //if it's null return this message
                    ResponseViewModel Response1 = new ResponseViewModel(false, HttpStatusCode.NoContent, "NoContent", null);
                    return Ok(Response1);
                }
                //if it's not null return this message
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", prod);
                return Ok(Response);
            }
            // if there is any other exception return this message            
            catch (Exception)
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.BadRequest, "failed", null);
                return Ok(Response);
            }
        }
        // POST api/<ProductionController>
        //request to add new production
        [HttpPost]
        [Route("/api/addproduction")]
        public async Task<ActionResult> AddProduction(StoreViewModel model)
        {
            try
            {
                await _production.AddProductionAsync(model);
                await _db.SaveChangesAsync();
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", model);
                return Ok(Response);
            }
            catch (Exception)
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.NoContent, "failed", null);
                return Ok(Response);
            }
        }

        //.........API Controllers for reporting Production reports (daily - montly - annual) .........
   
        [HttpGet]
        [Route("/api/getProductionReports")]

        public async Task<ActionResult<Production>> GetProductionReports(string period, DateTime from, DateTime to)
        {
            try
            {
                var production = await _production.GetProductinReports(period, from ,to);
                if (production == null)
                {
                    ResponseViewModel Response1 = new ResponseViewModel(false, HttpStatusCode.NoContent, "NoContent", null);
                    return Ok(Response1);
                }
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", production);
                return Ok(Response);
            }
            catch (Exception)
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.BadRequest, "failed", null);
                return Ok(Response);
            }
        }
        //// PUT api/<ProductionController>/5
        ////request to update an existing production 
        //[HttpPut]
        //[Route("/api/updateproduction/{id}")]
        //public async Task<ActionResult> Update(Production production, int id)
        //{
        //    try
        //    {
        //        await _production.UpdateProduction(id, production);
        //        await _db.SaveChangesAsync();
        //        var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", production);
        //        return Ok(Response);
        //    }

        //    catch (Exception)
        //    {
        //        var Response = new ResponseViewModel(false, HttpStatusCode.NoContent, "failed", null);
        //        return Ok(Response);
        //    }
        //}



        // DELETE api/<ProductionController>/5
        //request todelete specific production
        //[HttpDelete]
        //[Route("/api/deleteproduction/{id}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    var item = await _production.GetProduction(id);
        //    if (item == null)
        //    {
        //        var Response1 = new ResponseViewModel(false, HttpStatusCode.NoContent, "failed", null);
        //        return Ok(Response1);
        //    }
        //    await _production.DeleteProductionAsync(id);
        //    var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", null);
        //    return Ok(Response);
        //}


        //// GET: api/<ProductionController>
        ////request to get all production details 
        //[HttpGet]
        //[Route("/api/getallproduction")]
        //public async Task<ActionResult> GetAll()
        //{
        //    try
        //    {
        //        // call the required function from productionservice 
        //        var prod = await _production.GetAllProduction();
        //        //check if the returned has value 
        //        if (prod == null)
        //        {
        //             //if it's null return this message
        //            ResponseViewModel Response1 = new ResponseViewModel(false, HttpStatusCode.NoContent, "NoContent", null);
        //            return Ok(Response1);
        //        }
        //        //if it's not null return this message
        //        var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", prod);
        //        return Ok(Response);

        //    }
        //    // if there is any other exception return this message 
        //    catch (Exception)
        //    {
        //        var Response = new ResponseViewModel(false, HttpStatusCode.BadRequest, "failed", null);
        //        return Ok(Response);
        //    }
        //}

    }
}
