namespace VideoLibrary.BusinessEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingMovieActorEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieActor",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Role = c.String(),
                        ActorId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        AddedBy = c.Int(),
                        Actor_Id = c.Long(),
                        Movie_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Actor", t => t.Actor_Id)
                .ForeignKey("dbo.Movie", t => t.Movie_Id)
                .Index(t => t.Actor_Id)
                .Index(t => t.Movie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieActor", "Movie_Id", "dbo.Movie");
            DropForeignKey("dbo.MovieActor", "Actor_Id", "dbo.Actor");
            DropIndex("dbo.MovieActor", new[] { "Movie_Id" });
            DropIndex("dbo.MovieActor", new[] { "Actor_Id" });
            DropTable("dbo.MovieActor");
        }
    }
}
