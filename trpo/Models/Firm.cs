﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace trpo.Models
{
    public class Firm
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}