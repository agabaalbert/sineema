namespace VideoLibrary.BusinessEntities.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddGenre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actor", "Genre", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Actor", "Genre");
        }
    }
}
