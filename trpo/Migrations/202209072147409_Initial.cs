namespace trpo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Lifetime = c.Int(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Count = c.Int(nullable: false),
                        FirmId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Firms", t => t.FirmId, cascadeDelete: true)
                .Index(t => t.FirmId);
            
            CreateTable(
                "dbo.Firms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FinancingVolumes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Financing = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrganizationFinancingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrganizationFinancings", t => t.OrganizationFinancingId, cascadeDelete: true)
                .Index(t => t.OrganizationFinancingId);
            
            CreateTable(
                "dbo.OrganizationFinancings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Director = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Furnitures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Count = c.Int(nullable: false),
                        FirmId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Firms", t => t.FirmId, cascadeDelete: true)
                .Index(t => t.FirmId);
            
            CreateTable(
                "dbo.ResearchDirections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Researchers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Researches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ResearcherId = c.Int(nullable: false),
                        ResearchDirectionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ResearchDirections", t => t.ResearchDirectionId, cascadeDelete: true)
                .ForeignKey("dbo.Researchers", t => t.ResearcherId, cascadeDelete: true)
                .Index(t => t.ResearcherId)
                .Index(t => t.ResearchDirectionId);
            
            CreateTable(
                "dbo.StateResearches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ResearchesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Researches", t => t.ResearchesId, cascadeDelete: true)
                .Index(t => t.ResearchesId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StateResearches", "ResearchesId", "dbo.Researches");
            DropForeignKey("dbo.Researches", "ResearcherId", "dbo.Researchers");
            DropForeignKey("dbo.Researches", "ResearchDirectionId", "dbo.ResearchDirections");
            DropForeignKey("dbo.Furnitures", "FirmId", "dbo.Firms");
            DropForeignKey("dbo.FinancingVolumes", "OrganizationFinancingId", "dbo.OrganizationFinancings");
            DropForeignKey("dbo.Equipments", "FirmId", "dbo.Firms");
            DropIndex("dbo.StateResearches", new[] { "ResearchesId" });
            DropIndex("dbo.Researches", new[] { "ResearchDirectionId" });
            DropIndex("dbo.Researches", new[] { "ResearcherId" });
            DropIndex("dbo.Furnitures", new[] { "FirmId" });
            DropIndex("dbo.FinancingVolumes", new[] { "OrganizationFinancingId" });
            DropIndex("dbo.Equipments", new[] { "FirmId" });
            DropTable("dbo.StateResearches");
            DropTable("dbo.Researches");
            DropTable("dbo.Researchers");
            DropTable("dbo.ResearchDirections");
            DropTable("dbo.Furnitures");
            DropTable("dbo.OrganizationFinancings");
            DropTable("dbo.FinancingVolumes");
            DropTable("dbo.Firms");
            DropTable("dbo.Equipments");
            DropTable("dbo.Documents");
        }
    }
}
