﻿using System;
using System.Collections.Generic;

namespace Yamama.Models
{
    public partial class Photo
    {
        public int Idphoto { get; set; }
        public string Path { get; set; }
        public int? ProjectId { get; set; }
    }
}
