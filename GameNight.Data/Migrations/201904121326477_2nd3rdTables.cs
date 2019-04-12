namespace GameNight.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2nd3rdTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gamer",
                c => new
                    {
                        GamerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.GamerId);
            
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Genre = c.Int(nullable: false),
                        PlayerCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GameId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Game");
            DropTable("dbo.Gamer");
        }
    }
}
