﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WineData.MVC.Models
{
    public class WineModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Rate { get; set; }
    }
}