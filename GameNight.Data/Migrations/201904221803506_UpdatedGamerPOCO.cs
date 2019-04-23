namespace GameNight.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedGamerPOCO : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gamer", "Bio", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Gamer", "Bio");
        }
    }
}
