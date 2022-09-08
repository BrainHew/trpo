namespace trpo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using trpo.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<trpo.Models.trpoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(trpo.Models.trpoContext context)
        {
            context.Documents.AddOrUpdate(x => x.Id,
                 new Documents() { Id = 1, Name = "doc1" },
                 new Documents() { Id = 2, Name = "doc2" },
                 new Documents() { Id = 3, Name = "doc3" }
         );

            context.Equipments.AddOrUpdate(x => x.Id,
                new Equipment()
                {
                    Id = 1,
                    Name = "equipments1",
                    Lifetime = 5,
                    Cost = 350M,
                    Count = 9,
                    FirmId = 1,

                },
                new Equipment()
                {
                    Id = 2,
                    Name = "equipments2",
                    Lifetime = 5,
                    Cost = 350M,
                    Count = 9,
                    FirmId = 1,
                },
                new Equipment()
                {
                    Id = 3,
                    Name = "equipments3",
                    Lifetime = 5,
                    Cost = 350M,
                    Count = 9,
                    FirmId = 1,
                },
                new Equipment()
                {
                    Id = 4,
                    Name = "equipments4",
                    Lifetime = 5,
                    Cost = 350M,
                    Count = 9,
                    FirmId = 1,
                }
                );

            context.FinancingVolumes.AddOrUpdate(x => x.Id,
                new FinancingVolumes() { Id = 1, Financing = 2300M, OrganizationFinancingId = 1 },
                new FinancingVolumes() { Id = 2, Financing = 2300M, OrganizationFinancingId = 2 },
                new FinancingVolumes() { Id = 3, Financing = 2300M, OrganizationFinancingId = 3 }
                );

            context.Firms.AddOrUpdate(x => x.Id,
                new Firm() { Id = 1, Name = "firm1" },
                new Firm() { Id = 2, Name = "firm2" },
                new Firm() { Id = 3, Name = "firm3" }
                );

            context.Furnitures.AddOrUpdate(x => x.Id,
                new Furniture() { Id = 1, Name = "firm1", Cost = 350M, Count = 9, FirmId = 1 },
                new Furniture() { Id = 2, Name = "firm2", Cost = 350M, Count = 9, FirmId = 1 },
                new Furniture() { Id = 3, Name = "firm3", Cost = 350M, Count = 9, FirmId = 1 }
                );

            context.OrganizationFinancings.AddOrUpdate(x => x.Id,
                new OrganizationFinancing() { Id = 1, Name = "Orgfirm1", Director = "Malukov" },
                new OrganizationFinancing() { Id = 2, Name = "Orgfirm2", Director = "Klevanskiy" },
                new OrganizationFinancing() { Id = 3, Name = "Orgfirm3", Director = "Shpak" }
                );

            context.ResearchDirections.AddOrUpdate(x => x.Id,
                new ResearchDirection() { Id = 1, Name = "Mathemotika" },
                new ResearchDirection() { Id = 2, Name = "Orgfirm2" },
                new ResearchDirection() { Id = 3, Name = "Orgfirm3" }
                );

            context.Researchers.AddOrUpdate(x => x.Id,
                new Researcher() { Id = 1, Name = "vadim", Age = 22 },
                new Researcher() { Id = 2, Name = "sanya", Age = 34 },
                new Researcher() { Id = 3, Name = "egor", Age = 21 }
                );

            context.Researches.AddOrUpdate(x => x.Id,
                new Researches() { Id = 1, Name = "Orgfirm1", ResearcherId = 2, ResearchDirectionId = 1 },
                new Researches() { Id = 2, Name = "Orgfirm2", ResearcherId = 1, ResearchDirectionId = 1 },
                new Researches() { Id = 3, Name = "Orgfirm3", ResearcherId = 3, ResearchDirectionId = 1 }
                );

            context.StateResearches.AddOrUpdate(x => x.Id,
                new StateResearch() { Id = 1, ResearchesId = 3 },
                new StateResearch() { Id = 2, ResearchesId = 1 },
                new StateResearch() { Id = 3, ResearchesId = 2 }
                );
        }
    }
}
