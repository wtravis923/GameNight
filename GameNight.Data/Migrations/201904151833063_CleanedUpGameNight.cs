namespace GameNight.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CleanedUpGameNight : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.GameTime", "Game");
            DropColumn("dbo.GameTime", "NumberOfPlayers");
            DropColumn("dbo.GameTime", "Openings");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GameTime", "Openings", c => c.Boolean(nullable: false));
            AddColumn("dbo.GameTime", "NumberOfPlayers", c => c.Int(nullable: false));
            AddColumn("dbo.GameTime", "Game", c => c.String(nullable: false));
        }
    }
}
