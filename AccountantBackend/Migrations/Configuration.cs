namespace AccountantBackend.Migrations
{
    using System;
    using System.Collections.Generic;
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
                new Client()
                {
                    Name = "Tal",
                    Age = 19,
                    CompanyName = "Tal",
                    Address = "Hazon Ish 131",
                    LastUpdate = DateTime.Now,
                    Vat = new Vat()
                    {
                        VatId = 1,
                        Month = MonthEnum.JanFeb,
                        Expenses = new System.Collections.ObjectModel.Collection<Expense>()
                        {
                            new Expense()
                            {
                                ExpenseTitle = "Game",
                                Category = ExpenseCategory.House,
                                Amounts = new double[] { 30, 30, 40},
                                Total = 100,
                                VatAmount = 17,
                                AfterVat = 83,
                                Date = DateTime.Now
                            }
                        }
                    }
                });
        }
    }
}
