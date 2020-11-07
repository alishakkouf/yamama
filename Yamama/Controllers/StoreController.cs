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
    public class StoreController : ControllerBase
    {
        private readonly yamamadbContext _db;
        private readonly IStore _store;
        public StoreController(yamamadbContext db , IStore store)
        {
            _db = db;
            _store = store;

        }

        // POST api/<StoreController>
        [HttpPost]
        [Route("/api/addstore")]
        public async Task<ActionResult> Add(Store store)
        {
            try
            {
                await _store.AddstoreAsync(store);
                await _db.SaveChangesAsync();
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", store);
                return Ok(Response);

            }
            catch (Exception)
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.NoContent, "failed", null);
                return Ok(Response);
            }
        }


        // GET: api/<StoreController>
        [HttpGet]
        [Route("/api/getproductstore/{id}")]
        public async  Task<ActionResult> GetProductStore(int id)
        {
            try
            {
                int prodStore =  _store.GetProductStore(id);
                if (prodStore == null)
                {
                    ResponseViewModel Response1 = new ResponseViewModel(false, HttpStatusCode.NoContent, "NoContent", null);
                    return Ok(Response1);
                }
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", prodStore);
                return Ok(Response);
            }
            catch (Exception)
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.BadRequest, "failed", null);
                return Ok(Response);
            }
        }
        [HttpGet]
        [Route("/api/gettotalproductstore")]
        public async Task<ActionResult> GetTotalStore()
        {
            try
            {
                var prodStore = await _store.GetTotalStore();
                if (prodStore == null)
                {
                    ResponseViewModel Response1 = new ResponseViewModel(false, HttpStatusCode.NoContent, "NoContent", null);
                    return Ok(Response1);
                }

                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", prodStore);
                return Ok(Response);

            }
            catch (Exception)
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.BadRequest, "failed", null);
                return Ok(Response);
            }
        }
    }
}
