﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Web.FlickrSystem.Models.Entities
{
    public class LocationSearchCache
    {
        public int Id { get; set; }
        public string SearchText { get; set; }
        public string Result { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
