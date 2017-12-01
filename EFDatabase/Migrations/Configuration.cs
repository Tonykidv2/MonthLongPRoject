namespace EFDatabase.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EFDatabase.TBL.EmployeeManagementContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EFDatabase.TBL.EmployeeManagementContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.States.AddOrUpdate(
                p => p.Name,
                new TBL.State { Name = "AL"},
                new TBL.State { Name = "AK" },
                new TBL.State { Name = "AR" },
                new TBL.State { Name = "CA" },
                new TBL.State { Name = "CO" },
                new TBL.State { Name = "CT" },
                new TBL.State { Name = "DE" },
                new TBL.State { Name = "FL" },
                new TBL.State { Name = "GA" },
                new TBL.State { Name = "HI" },
                new TBL.State { Name = "ID" },
                new TBL.State { Name = "IL" },
                new TBL.State { Name = "IN" },
                new TBL.State { Name = "IA" },
                new TBL.State { Name = "KS" },
                new TBL.State { Name = "KY" },
                new TBL.State { Name = "LA" },
                new TBL.State { Name = "ME" },
                new TBL.State { Name = "MD" },
                new TBL.State { Name = "MA" },
                new TBL.State { Name = "MI" },
                new TBL.State { Name = "MN" },
                new TBL.State { Name = "MS" },
                new TBL.State { Name = "MO" },
                new TBL.State { Name = "MT" },
                new TBL.State { Name = "NE" },
                new TBL.State { Name = "NV" },
                new TBL.State { Name = "NH" },
                new TBL.State { Name = "NJ" },
                new TBL.State { Name = "NM" },
                new TBL.State { Name = "NY" },
                new TBL.State { Name = "NC" },
                new TBL.State { Name = "ND" },
                new TBL.State { Name = "OH" },
                new TBL.State { Name = "OK" },
                new TBL.State { Name = "OR" },
                new TBL.State { Name = "PA" },
                new TBL.State { Name = "RI" },
                new TBL.State { Name = "SC" },
                new TBL.State { Name = "SD" },
                new TBL.State { Name = "TN" },
                new TBL.State { Name = "TX" },
                new TBL.State { Name = "UT" },
                new TBL.State { Name = "VT" },
                new TBL.State { Name = "VA" },
                new TBL.State { Name = "WA" },
                new TBL.State { Name = "WV" },
                new TBL.State { Name = "WI" },
                new TBL.State { Name = "WY" },
                new TBL.State { Name = "PR" }
            );

            context.Educations.AddOrUpdate(
                p => p.Name,
                new TBL.Education { Name = "B.E"},
                new TBL.Education { Name = "B.Tech" },
                new TBL.Education { Name = "B.S" },
                new TBL.Education { Name = "C.S" },
                new TBL.Education { Name = "M.B.A" },
                new TBL.Education { Name = "M.C.A" }
            );
        }
    }
}
