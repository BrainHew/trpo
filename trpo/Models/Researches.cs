using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace trpo.Models
{
    public class Researches
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        // Foreign Key
        public int ResearcherId { get; set; }
        // Navigation property
        public Researcher Researcher { get; set; }
        // Foreign Key
        public int ResearchDirectionId { get; set; }
        // Navigation property
        public ResearchDirection ResearchDirection { get; set; }
    }
}