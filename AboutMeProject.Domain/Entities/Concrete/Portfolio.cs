﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Domain.Entities.Concrete
{
   public class Portfolio : BaseEntity<int>
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}