namespace GameNight.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedGamerProfile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gamer", "GamerTag", c => c.String());
            DropColumn("dbo.ApplicationUser", "GamerTag");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationUser", "GamerTag", c => c.String());
            DropColumn("dbo.Gamer", "GamerTag");
        }
    }
}
