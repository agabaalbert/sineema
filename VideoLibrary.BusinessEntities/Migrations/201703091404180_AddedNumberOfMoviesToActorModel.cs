namespace VideoLibrary.BusinessEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNumberOfMoviesToActorModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actor", "NumberOfMovies", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Actor", "NumberOfMovies");
        }
    }
}
