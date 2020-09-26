namespace AccountantBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vats", "TotalExpenses", c => c.Double(nullable: false));
            AddColumn("dbo.Vats", "TotalVat", c => c.Double(nullable: false));
            AddColumn("dbo.Vats", "AfterVat", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vats", "AfterVat");
            DropColumn("dbo.Vats", "TotalVat");
            DropColumn("dbo.Vats", "TotalExpenses");
        }
    }
}
