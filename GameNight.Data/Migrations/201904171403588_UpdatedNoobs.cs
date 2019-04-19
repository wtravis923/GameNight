namespace GameNight.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedNoobs : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GameTime", "NoobsAllowed", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GameTime", "NoobsAllowed", c => c.Boolean(nullable: false));
        }
    }
}
