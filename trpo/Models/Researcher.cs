using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace trpo.Models
{
    public class Researcher
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int Age { get; set; }
    }
}