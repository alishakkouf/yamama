﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yamama;
//using Yamama.Models;
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
        [Route("AddBalance")]
        public async Task<IActionResult> AddBalance(string  name)
       {
            try
            {
                var blnce = await _balance.AddBalanceAsync(name);

                if (blnce == 0)
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
        [Route("GetProductLastByQty")]
        public async Task<ActionResult<Balance>> GetProductLastByQty(DateTime date ,string name)
        {
            try
            {
                var balance =await  _balance.GetProductBalanceQty(date, name);
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
        [Route("GetBalanceByPrice")]
        public async Task<ActionResult<Balance>> GetBalanceByPrice(DateTime date, string name)
        {
            try
            {
                var balance = await _balance.GetProductBalancePrice(date, name);
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
        [Route("GetBalanceByQty")]
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
       // [HttpGet]
       // [Route("GetBalanceByPrice")]
       // public async Task<ActionResult<Balance>> GetBalanceByPrice(DateTime date)
       //{
       //     try
       //     {
       //         var balance = await _balance.GetBalancePrice(date);
       //         //check if the item has value if not  return msg no content
       //         if (balance == null)
       //         {
       //             ResponseViewModel Response1 = new ResponseViewModel(false, HttpStatusCode.NoContent, "NoContent", null);
       //             return Ok(Response1);
       //         }
       //         //if the item has value  return succes
       //         var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", balance);
       //         return Ok(Response);
       //     }
       //     //if the operation faild cause of syntax errors or servers errors
       //     catch (Exception)
       //     {
       //         var Response = new ResponseViewModel(false, HttpStatusCode.BadRequest, "failed", null);
       //         return Ok(Response);
       //     }

       // }

        /// report last period Value(ton) for all products 
        [HttpGet]
        [Route("GetAllBalanceByPrice")]
        public async Task<ActionResult<Balance>> GetAllBalanceByPrice(DateTime date)
        {
            try
            {
                var balance = await _balance.GetAllBalancePrice(date);
                //check if the item has value if not  return msg no content
                if (balance == 0)
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
