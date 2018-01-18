namespace VideoLibrary.BusinessEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedYearToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movie", "Year", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movie", "Year");
        }
    }
}
