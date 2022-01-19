namespace PetShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Species : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Species (Id, Name) VALUES (1, 'Rabbit')");
            Sql("INSERT INTO Species (Id, Name) VALUES (2, 'Hamster')");
            Sql("INSERT INTO Species (Id, Name) VALUES (3, 'Guinny Pig')");
        }
        
        public override void Down()
        {
        }
    }
}
