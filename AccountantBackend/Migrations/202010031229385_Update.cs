namespace AccountantBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IdCard = c.String(),
                        BirthYear = c.Int(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                        GreenUsername = c.String(),
                        GreenPassword = c.String(),
                        LastUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.Vats",
                c => new
                    {
                        VatId = c.Int(nullable: false, identity: true),
                        Month = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        TotalExpenses = c.Double(nullable: false),
                        TotalVat = c.Double(nullable: false),
                        AfterVat = c.Double(nullable: false),
                        Client_ClientId = c.Int(),
                    })
                .PrimaryKey(t => t.VatId)
                .ForeignKey("dbo.Clients", t => t.Client_ClientId)
                .Index(t => t.Client_ClientId);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        ExpenseId = c.Int(nullable: false, identity: true),
                        ExpenseTitle = c.String(),
                        Category = c.Int(nullable: false),
                        Total = c.Double(nullable: false),
                        VatAmount = c.Double(nullable: false),
                        AfterVat = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Vat_VatId = c.Int(),
                    })
                .PrimaryKey(t => t.ExpenseId)
                .ForeignKey("dbo.Vats", t => t.Vat_VatId)
                .Index(t => t.Vat_VatId);
            
            CreateTable(
                "dbo.Profits",
                c => new
                    {
                        ProfitId = c.Int(nullable: false),
                        ProfitTitle = c.String(),
                        Total = c.Double(nullable: false),
                        DealsVat = c.Double(nullable: false),
                        AfterVat = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ProfitId)
                .ForeignKey("dbo.Vats", t => t.ProfitId)
                .Index(t => t.ProfitId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vats", "Client_ClientId", "dbo.Clients");
            DropForeignKey("dbo.Profits", "ProfitId", "dbo.Vats");
            DropForeignKey("dbo.Expenses", "Vat_VatId", "dbo.Vats");
            DropIndex("dbo.Profits", new[] { "ProfitId" });
            DropIndex("dbo.Expenses", new[] { "Vat_VatId" });
            DropIndex("dbo.Vats", new[] { "Client_ClientId" });
            DropTable("dbo.Profits");
            DropTable("dbo.Expenses");
            DropTable("dbo.Vats");
            DropTable("dbo.Clients");
        }
    }
}
