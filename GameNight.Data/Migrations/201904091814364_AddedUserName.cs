namespace GameNight.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "Name", c => c.String());
            AddColumn("dbo.ApplicationUser", "Bio", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUser", "Bio");
            DropColumn("dbo.ApplicationUser", "Name");
        }
    }
}
