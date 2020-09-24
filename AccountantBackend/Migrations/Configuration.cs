namespace AccountantBackend.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using AccountantBackend.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<AccountantBackend.Models.ClientContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AccountantBackend.Models.ClientContext context)
        {
            context.Clients.AddOrUpdate(x => x.Name,
                new Client() { Name = "Tal", Age = 19, CompanyName = "Tal", Address = "Hazon Ish 131", LastUpdate = DateTime.Now },
                new Client() { Name = "Rotem", Age = 15, CompanyName = "Rotem", Address = "Hazon Ish 131", LastUpdate = DateTime.Now },
                new Client() { Name = "Or", Age = 8, CompanyName = "Or", Address = "Hazon Ish 131", LastUpdate = DateTime.Now }
                );
        }
    }
}
