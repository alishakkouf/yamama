using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account.Manage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Yamama.Models;
using Yamama.Repository;


namespace Yamama.Services
{
    public class PhotoService : IPhoto
    {
      private readonly  yamamadbContext _db;
        public PhotoService(yamamadbContext db)
        {
            _db = db;
        }
        public async Task<int> AddPhotoAsync(Photo photo)
        {
            int result = 0;
            // add new photo
            await _db.Photo.AddAsync(photo);
            //if the operation succecced return 1
            result += 1;
            return result;
        }
        //...............

        //get all project photos 
        public  async Task<List<Photo>> ListPhotos(int id)
        {
            //check if the dbcontext is not null

            if (_db != null)
            {
                // if not retuen the photos that relate to specifiic project based on project id
                return await (from ph in _db.Photo
                              where ph.ProjectId == id
                              select new Photo {Idphoto=ph.Idphoto, Path = ph.Path/*, Name = ph.Name*/ }
                              ).ToListAsync();

            };

            return null;
        }

    
    }
}
