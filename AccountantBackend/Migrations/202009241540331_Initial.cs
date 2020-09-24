namespace AccountantBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Age = c.Int(nullable: false),
                        CompanyName = c.String(),
                        Address = c.String(),
                        LastUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clients");
        }
    }
}
