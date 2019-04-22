namespace GameNight.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.GameTime", "Title");
            DropColumn("dbo.GameTime", "Genre");
            DropColumn("dbo.GameTime", "PlayerCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GameTime", "PlayerCount", c => c.Int(nullable: false));
            AddColumn("dbo.GameTime", "Genre", c => c.Int(nullable: false));
            AddColumn("dbo.GameTime", "Title", c => c.String());
        }
    }
}
