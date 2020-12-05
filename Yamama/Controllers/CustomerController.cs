using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yamama.Repository;
using Yamama.ViewModels;

namespace Yamama.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly Iquestionnaire _question;

        public CustomerController(Iquestionnaire iquestionnaire)
        {
            _question = iquestionnaire;
        }
        //POST api/<CustomerController>
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        [Route("Question")]
        public async Task<IActionResult> Question(QuestionnaireViewModel questionnaireViewModel)
        {

            var result = await _question.AddQuestionnaire(questionnaireViewModel);
            if (result != 0)
            {
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", result);
                return Ok(Response);
            }
            else
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.NoContent, "failed", null);
                return Ok(Response);
            }

        }
        

        //POST api/<CustomerController>
        [HttpGet]
        //[Authorize(Roles = "Admin")] 
        [Route("GetQuestion")]
        public async Task<IActionResult> GetQuestion(int factory, int project)
        {

            var result = await _question.GetQuestionnaireTexts(factory, project);
            if (result != null)
            {
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", result);
                return Ok(Response);
            }
            else
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.NoContent, "failed", null);
                return Ok(Response);
            }

        }

        [HttpPost]
        //[Authorize(Roles = "Admin")] 
        [Route("AddQuestionModel")]
        public async Task<IActionResult> AddQuestionModel(fullQuestionModel questionModel) 
        {
            var result = await _question.AddQuestionModel(questionModel);
            if (result != null)
            {
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", result);
                return Ok(Response);
            }
            else
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.NoContent, "failed", null);
                return Ok(Response);
            }
        }


        [HttpPost]
        //[Authorize(Roles = "Admin")] 
        [Route("AddModelName")]
        public async Task<IActionResult> AddModelName(string name)
        {
            var result = await _question.AddModelName(name);
            if (result == "success")
            {
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", result);
                return Ok(Response);
            }
            else
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.NoContent, "failed", null);
                return Ok(Response);
            }
        }
    }
}