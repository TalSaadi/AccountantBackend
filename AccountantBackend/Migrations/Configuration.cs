namespace AccountantBackend.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
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
                    IdCard = "212214829",
                    BirthYear = 2001,
                    Username = "talsaadi36",
                    Password = "asdfjiasdf",
                    GreenUsername = "talsaadi",
                    GreenPassword = "cvnvxzcnvi",
                    LastUpdate = DateTime.Now,
                    Vats = new Collection<Vat>()
                    {
                        new Vat()
                        {
                            VatId = 1,
                            Year = 2020,
                            Month = MonthEnum.JanFeb,
                            TotalExpenses = 100,
                            TotalVat = 17,
                            AfterVat = 83,
                            Profit = new Profit()
                            {
                                ProfitTitle = "Consult",
                                Amounts = new Collection<double>() {30, 30, 40},
                                Total = 100,
                                DealsVat = 17,
                                AfterVat = 83
                            },
                            Expenses = new Collection<Expense>()
                            {
                                new Expense()
                                {
                                    ExpenseTitle = "Game",
                                    Category = ExpenseCategory.House,
                                    Amounts = new Collection<double>() { 30, 30, 40},
                                    Total = 100,
                                    VatAmount = 17,
                                    AfterVat = 83,
                                    Date = DateTime.Now
                                }
                            }
                        }
                    }
                });
        }
    }
}
