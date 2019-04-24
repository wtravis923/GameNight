namespace GameNight.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GameTime", "GamerId", "dbo.Gamer");
            DropIndex("dbo.GameTime", new[] { "GamerId" });
            AddColumn("dbo.GameTime", "GamerTag", c => c.String());
            DropColumn("dbo.GameTime", "GamerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GameTime", "GamerId", c => c.Int(nullable: false));
            DropColumn("dbo.GameTime", "GamerTag");
            CreateIndex("dbo.GameTime", "GamerId");
            AddForeignKey("dbo.GameTime", "GamerId", "dbo.Gamer", "GamerId", cascadeDelete: true);
        }
    }
}
