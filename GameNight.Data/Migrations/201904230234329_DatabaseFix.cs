namespace GameNight.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gamer", "PlayerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Gamer", "PlayerId");
        }
    }
}
