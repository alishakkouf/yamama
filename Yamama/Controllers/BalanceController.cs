using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yamama;
using Yamama.Repository;
using Yamama.ViewModels;

namespace Yamama.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalanceController : ControllerBase
    {

        private readonly yamamadbContext _db;

        private readonly IBalance _balance;

        public BalanceController( IBalance balance, yamamadbContext db)
        {
            _balance = balance;
            _db = db;
        }

        [HttpPost]
        [Route("/api/addbalance/{id}")]

        public async Task<ActionResult> AddBalanceAsync(int id)
       {
            try
            {
                int blnce = await _balance.AddBalanceAsync(id);

                if (blnce == null)
                {
                    ResponseViewModel Response1 = new ResponseViewModel(false, HttpStatusCode.NoContent, "NoContent", null);
                    return Ok(Response1);
                }
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", blnce);
                return Ok(blnce);
            }
            catch (Exception)
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.BadRequest, "failed", null);
                return Ok(Response);
            }

        }

        /// report last period quantity by product 
        [HttpGet]
        [Route("/api/getproductlastqty")]
        public async Task<ActionResult<Balance>> GetProductLastByQty(DateTime date ,int id)
        {
            try
            {
                var balance =await  _balance.GetProductBalanceQty(date, id);
                //check if the item has value if not  return msg no content
                if (balance == null)
                {
                    ResponseViewModel Response1 = new ResponseViewModel(false, HttpStatusCode.NoContent, "NoContent", null);
                    return Ok(Response1);
                }
                //if the item has value  return succes
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", balance);
                return Ok(Response);
            }
            //if the operation faild cause of syntax errors or servers errors
            catch (Exception)
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.BadRequest, "failed", null);
                return Ok(Response);
            }

        }
        //report last period value(ton) by product

        [HttpGet]
        [Route("/api/getproductlastprice")]
        public async Task<ActionResult<Balance>> GetBalanceByPrice(DateTime date, int id)
        {
            try
            {
                var balance = await _balance.GetProductBalancePrice(date, id);
                //check if the item has value if not  return msg no content
                if (balance == null)
                {
                    ResponseViewModel Response1 = new ResponseViewModel(false, HttpStatusCode.NoContent, "NoContent", null);
                    return Ok(Response1);
                }
                //if the item has value  return succes
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", balance);
                return Ok(Response);
            }
            //if the operation faild cause of syntax errors or servers errors
            catch (Exception)
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.BadRequest, "failed", null);
                return Ok(Response);
            }

        }


        /// report last period quantity for all products 
        [HttpGet]
        [Route("/api/getlastallqty")]
        public async Task<ActionResult<Balance>> GetBalanceByQty(DateTime date)
        {
            try
            {
                var balance = await _balance.GetBalanceQty(date);
                //check if the item has value if not  return msg no content
                if (balance == null)
                {
                    ResponseViewModel Response1 = new ResponseViewModel(false, HttpStatusCode.NoContent, "NoContent", null);
                    return Ok(Response1);
                }
                //if the item has value  return succes
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", balance);
                return Ok(Response);
            }
            //if the operation faild cause of syntax errors or servers errors
            catch (Exception)
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.BadRequest, "failed", null);
                return Ok(Response);
            }
        }
        /// report last period Value(ton) for all products 
        [HttpGet]
        [Route("/api/getlistlastallprice")]
        public async Task<ActionResult<Balance>> GetBalanceByPrice(DateTime date)
       {
            try
            {
                var balance = await _balance.GetBalancePrice(date);
                //check if the item has value if not  return msg no content
                if (balance == null)
                {
                    ResponseViewModel Response1 = new ResponseViewModel(false, HttpStatusCode.NoContent, "NoContent", null);
                    return Ok(Response1);
                }
                //if the item has value  return succes
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", balance);
                return Ok(Response);
            }
            //if the operation faild cause of syntax errors or servers errors
            catch (Exception)
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.BadRequest, "failed", null);
                return Ok(Response);
            }

        }

        /// report last period Value(ton) for all products 
        [HttpGet]
        [Route("/api/getlastallprice")]
        public async Task<ActionResult<Balance>> GetAllBalanceByPrice(DateTime date)
        {
            try
            {
                var balance = await _balance.GetAllBalancePrice(date);
                //check if the item has value if not  return msg no content
                if (balance == null)
                {
                    ResponseViewModel Response1 = new ResponseViewModel(false, HttpStatusCode.NoContent, "NoContent", null);
                    return Ok(Response1);
                }
                //if the item has value  return succes
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", balance);
                return Ok(Response);
            }
            //if the operation faild cause of syntax errors or servers errors
            catch (Exception)
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.BadRequest, "failed", null);
                return Ok(Response);
            }

        }
    }
}
