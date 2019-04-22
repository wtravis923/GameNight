namespace GameNight.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedPOCO : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameTime", "Title", c => c.String());
            AddColumn("dbo.GameTime", "Genre", c => c.Int(nullable: false));
            AddColumn("dbo.GameTime", "PlayerCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameTime", "PlayerCount");
            DropColumn("dbo.GameTime", "Genre");
            DropColumn("dbo.GameTime", "Title");
        }
    }
}
