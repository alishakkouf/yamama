using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Yamama.Repository
{
  public   interface IPhoto
    {
     
        //add new photo
        Task<int> AddPhotoAsync(Photo photo);

        //get list of  specific project photos 
        Task<List<Photo>> ListPhotos(int id);
    }
}
