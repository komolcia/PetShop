namespace PetShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FewErrorMessages : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Customers", "LastName", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Pets", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pets", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Customers", "LastName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
