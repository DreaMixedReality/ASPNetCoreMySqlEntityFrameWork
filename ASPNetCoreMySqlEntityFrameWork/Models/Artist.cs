﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMySqlEntityFrameWork.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Album> Albums { get; set; }
    }
}
