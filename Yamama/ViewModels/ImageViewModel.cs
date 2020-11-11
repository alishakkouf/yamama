using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yamama.ViewModels
{
    public class ImageViewModel
    {
        public IFormFile photo { get; set; }
        public string Name { get; set; }

        public int? ProjectId { get; set; }

    }
}
