﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyFast.API.Models
{
    public class Plane
    {
        public Plane()
        {
            this.Customers = new List<Customer>();
        }
        //public Int32 Places { get; set; }
        public List<Customer> Customers { get; set; }
    }
}