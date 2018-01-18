namespace VideoLibrary.BusinessEntities.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddLeadActor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movie", "Actor_Id", "dbo.Actor");
            DropIndex("dbo.Movie", new[] { "Actor_Id" });
            RenameColumn(table: "dbo.Movie", name: "Actor_Id", newName: "LeadActorId");
            AlterColumn("dbo.Movie", "LeadActorId", c => c.Long(nullable: false));
            CreateIndex("dbo.Movie", "LeadActorId");
            AddForeignKey("dbo.Movie", "LeadActorId", "dbo.Actor", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movie", "LeadActorId", "dbo.Actor");
            DropIndex("dbo.Movie", new[] { "LeadActorId" });
            AlterColumn("dbo.Movie", "LeadActorId", c => c.Long());
            RenameColumn(table: "dbo.Movie", name: "LeadActorId", newName: "Actor_Id");
            CreateIndex("dbo.Movie", "Actor_Id");
            AddForeignKey("dbo.Movie", "Actor_Id", "dbo.Actor", "Id");
        }
    }
}
