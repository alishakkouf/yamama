using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yamama.Models;
using Yamama.Repository;


namespace Yamama.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitController : ControllerBase
    {
        private readonly IVisit _visit;
        private readonly yamamaContext _db;

        public VisitController(yamamaContext db, IVisit visit)
        {
            _visit = visit;
            _db = db;
        }


        // POST api/<VisitController>
        [HttpPost("/api/visits")]
        public ActionResult Add(Visit visit)
        {
            try
            {
                _visit.AddVisit(visit);
                _db.SaveChanges();

                return Ok();
            }

            catch
            {
                return BadRequest();
            }
        }

        // GET: api/<VisitController>
        [HttpGet("/api/visits")]
        public async Task<ActionResult> ArchiveVisit()
        {
            try
            {
                var item = _visit.ArchiveVisit();
                return Ok(item);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/<VisitController>
        [HttpGet("/api/visits")]
        public async Task<ActionResult> GetAllVisits()
        {
            try
            {
                var item = _visit.GetAllVisits();
                return Ok(item);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/<VisitController>
        [HttpGet("/api/visits")]
        public async Task<ActionResult> NewAssignedVisits()
        {
            try
            {
                var item = _visit.NewAssignedVisits();
                return Ok(item);
            }
            catch
            {
                return BadRequest();
            }
        }


        // GET api/<VisitController>/
        [HttpGet("/api/visits/{id}")]
        public ActionResult<Visit> VisitReport(int id)
        {
            try
            {
                return _visit.VisitReport(id);
            }
            catch
            {
                return BadRequest();
            }

        }
    }
}