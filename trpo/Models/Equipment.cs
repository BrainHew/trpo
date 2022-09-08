using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace trpo.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int Lifetime { get; set; }

        public decimal Cost { get; set; }

        public int Count { get; set; }

        // Foreign Key
        public int FirmId { get; set; }
        // Navigation property
        public Firm Firm { get; set; }
    }
}