using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace trpo.Models
{
    public class StateResearch
    {
        public int Id { get; set; }
        [Required]

        // Foreign Key
        public int ResearchesId { get; set; }
        // Navigation property
        public Researches Researches { get; set; }
    }
}