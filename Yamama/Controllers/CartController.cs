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
    public class CartController : ControllerBase
    {

        private readonly yamamadbContext _db;

        private readonly ICart _cart;

        
        public CartController(yamamadbContext db, ICart cart)
        {
            _db = db;
            _cart = cart;


        }

        // POST api/<ImportInvoiceController>
        [HttpPost]
        [Route("/api/addimportcart")]
        public async Task<ActionResult> addimportcart(InvoiceCartViewModel invoiceCart, int id)
        {
            try
            {
                await _cart.AddCartAsync(invoiceCart, id);
             
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", invoiceCart);
                return Ok(Response);

            }

            catch (Exception)
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.NoContent, "failed", null);
                return Ok(Response);
            }
        }
    }
}
