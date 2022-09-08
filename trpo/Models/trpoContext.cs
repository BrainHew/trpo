using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace trpo.Models
{
    public class trpoContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public trpoContext() : base("name=trpoContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public System.Data.Entity.DbSet<trpo.Models.Documents> Documents { get; set; }

        public System.Data.Entity.DbSet<trpo.Models.Equipment> Equipments { get; set; }

        public System.Data.Entity.DbSet<trpo.Models.Firm> Firms { get; set; }

        public System.Data.Entity.DbSet<trpo.Models.FinancingVolumes> FinancingVolumes { get; set; }

        public System.Data.Entity.DbSet<trpo.Models.OrganizationFinancing> OrganizationFinancings { get; set; }

        public System.Data.Entity.DbSet<trpo.Models.Furniture> Furnitures { get; set; }

        public System.Data.Entity.DbSet<trpo.Models.ResearchDirection> ResearchDirections { get; set; }

        public System.Data.Entity.DbSet<trpo.Models.Researcher> Researchers { get; set; }

        public System.Data.Entity.DbSet<trpo.Models.Researches> Researches { get; set; }

        public System.Data.Entity.DbSet<trpo.Models.StateResearch> StateResearches { get; set; }
    }
}
