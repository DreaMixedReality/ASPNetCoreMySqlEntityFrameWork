using System;
using System.Collections.Generic;

namespace ASPNetCoreMySqlEntityFrameWork.Models
{
    public partial class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ArtistName { get; set; }
        public int Price { get; set; }
        public string Genre { get; set; }
    }
}
