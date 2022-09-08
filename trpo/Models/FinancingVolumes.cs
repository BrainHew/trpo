using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace trpo.Models
{
    public class FinancingVolumes
    {
        public int Id { get; set; }
        [Required]
        public decimal Financing { get; set; }

        // Foreign Key
        public int OrganizationFinancingId { get; set; }
        // Navigation property
        public OrganizationFinancing OrganizationFinancing { get; set; }

    }
}