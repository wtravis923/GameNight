namespace GameNight.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedHostToGameNight : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameTime", "GamerId", c => c.Int(nullable: false));
            CreateIndex("dbo.GameTime", "GamerId");
            AddForeignKey("dbo.GameTime", "GamerId", "dbo.Gamer", "GamerId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameTime", "GamerId", "dbo.Gamer");
            DropIndex("dbo.GameTime", new[] { "GamerId" });
            DropColumn("dbo.GameTime", "GamerId");
        }
    }
}
