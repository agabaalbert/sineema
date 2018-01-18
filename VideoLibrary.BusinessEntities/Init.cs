using System.Data.Entity;

namespace VideoLibrary.BusinessEntities
{
    public class Init : MigrateDatabaseToLatestVersion<LibraryContext, Migrations.Configuration> { }
}
