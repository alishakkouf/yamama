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
    public class ProductController : ControllerBase
    {

        private readonly yamamadbContext _db;
        private readonly IProduct _product;

        public ProductController(yamamadbContext db, IProduct product)
        {
            _db = db;
            _product = product;

        }
      
        // to get product details

        [HttpGet]
        [Route("/api/getproduct")]
        public async Task<ActionResult<Product>> getproduct(string name)
        {
            try
            {
                var product = await _product.GetProduct(name);
                //check if the item has value if not  return msg no content
                if (product == null)
                {
                    ResponseViewModel Response1 = new ResponseViewModel(false, HttpStatusCode.NoContent, "NoContent", null);
                    return Ok(Response1);
                }
                //if the item has value  return succes
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", product);
                return Ok(Response);
            }
            //if the operation faild cause of syntax errors or servers errors
            catch (Exception)
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.BadRequest, "failed", null);
                return Ok(Response);
            }

        }

        //[HttpGet]
        //[Route("/api/getproductprice")]
        //public async Task<IActionResult> getproductprice(int id)
        //{
        //    try
        //    {
        //        var product = await _product.GetProductPrice(id);
        //        //check if the item has value if not  return msg no content
        //        if (product == 0)
        //        {
        //            ResponseViewModel Response1 = new ResponseViewModel(false, HttpStatusCode.NoContent, "NoContent", null);
        //            return Ok(Response1);
        //        }
        //        //if the item has value  return succes
        //        var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", product);
        //        return Ok(Response);
        //    }
        //    //if the operation faild cause of syntax errors or servers errors
        //    catch (Exception)
        //    {
        //        var Response = new ResponseViewModel(false, HttpStatusCode.BadRequest, "failed", null);
        //        return Ok(Response);
        //    }

        //}

    }
}
