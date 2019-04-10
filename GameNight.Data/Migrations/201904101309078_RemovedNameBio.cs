namespace GameNight.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedNameBio : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ApplicationUser", "Name");
            DropColumn("dbo.ApplicationUser", "Bio");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationUser", "Bio", c => c.String());
            AddColumn("dbo.ApplicationUser", "Name", c => c.String());
        }
    }
}
