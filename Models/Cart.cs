﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace truyum_WebAPIPracticeCheck.Models
{
    public class Cart
    {

        [Key]
        public int CartId { get; set; }
        public MenuItem MenuItem { get; set; }
        public int MenuItemId { get; set; }
    }
}
