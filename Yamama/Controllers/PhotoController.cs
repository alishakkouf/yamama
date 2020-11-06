using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yamama.Repository;
using Yamama.ViewModels;

namespace Yamama.Controllers
{
    public class PhotoController : Controller
    {

        private readonly IPhoto _photo;
        private readonly yamamadbContext _db;
        public static IHostingEnvironment _env;
        public PhotoController(IPhoto photo, yamamadbContext db , IHostingEnvironment env)
        {
            _photo = photo;
            _db = db;
            _env = env;

        }
       


        // get projects photos 
        [HttpGet]
        [Route("/api/getprojectphotos/{id}")]

        public async Task<ActionResult<Photo>> GetProjectPhotos(int id)
        {
            try
            {
                var photo = await _photo.ListPhotos(id);
                if (photo == null)
                {
                    ResponseViewModel Response1 = new ResponseViewModel(false, HttpStatusCode.NoContent, "NoContent", null);
                    return Ok(Response1);
                }
                var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", photo);
                return Ok(Response);
            }
            catch (Exception)
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.BadRequest, "failed", null);
                return Ok(Response);
            }

        }
        // POST api/<PhotoController>
        [HttpPost]
        [Route("/api/addphoto")]
        public async Task<ActionResult> Add(ImageViewModel model)
        {
            try
            {
                //check if the sent model not null
                if (ModelState.IsValid)
                {

                    // declare a variable 
                    string fileName = null;

                    //check if the sent model has a photo
                    if (model.photo != null)
                    {
                        //declare a variable and stor in it the path of the uploaded files and photos
                        string uploading = Path.Combine(_env.WebRootPath, "Upload");

                        //give the uploaded file a unique name

                        fileName = Guid.NewGuid().ToString() + "_" + model.photo.FileName;

                        // declare a variable and store in it the name of file and the path
                        string filePath = Path.Combine(uploading, fileName);

                        model.photo.CopyTo(new FileStream(filePath, FileMode.Create));
                    }
                    //create a new object from photo class 
                    Photo newphoto = new Photo
                    {
                        Path = fileName,
                        ProjectId = model.ProjectId,
                        Name = model.Name,
                     

                    };

                    // add the new photo object to the database
                    await _photo.AddPhotoAsync(newphoto);
                    //save the changes
                    await _db.SaveChangesAsync();
                    var Response = new ResponseViewModel(true, HttpStatusCode.OK, "SUCCESS", newphoto);
                    return Ok(Response);

                }

                return null;
            }

            catch (Exception)
            {
                var Response = new ResponseViewModel(false, HttpStatusCode.NoContent, "failed", null);
                return Ok(Response);
            }
        }
    }
}
