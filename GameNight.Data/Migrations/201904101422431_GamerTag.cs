namespace GameNight.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GamerTag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "GamerTag", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUser", "GamerTag");
        }
    }
}
