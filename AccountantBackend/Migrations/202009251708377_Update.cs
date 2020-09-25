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
                        Age = c.Int(nullable: false),
                        CompanyName = c.String(),
                        Address = c.String(),
                        LastUpdate = c.DateTime(nullable: false),
                        VatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClientId)
                .ForeignKey("dbo.Vats", t => t.VatId, cascadeDelete: true)
                .Index(t => t.VatId);
            
            CreateTable(
                "dbo.Vats",
                c => new
                    {
                        VatId = c.Int(nullable: false, identity: true),
                        Month = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VatId);
            
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
                        VatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExpenseId)
                .ForeignKey("dbo.Vats", t => t.VatId, cascadeDelete: true)
                .Index(t => t.VatId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "VatId", "dbo.Vats");
            DropForeignKey("dbo.Expenses", "VatId", "dbo.Vats");
            DropIndex("dbo.Expenses", new[] { "VatId" });
            DropIndex("dbo.Clients", new[] { "VatId" });
            DropTable("dbo.Expenses");
            DropTable("dbo.Vats");
            DropTable("dbo.Clients");
        }
    }
}
