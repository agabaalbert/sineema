using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using VideoLibrary.BusinessEntities;
using VideoLibrary.BusinessEntities.Migrations;
using System.Data.Entity;

namespace VideoLibrary
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            #region DEBUG
#if DEBUG
           // Database.SetInitializer(new Init());
          // Database.SetInitializer<LibraryContext>(new DropCreateDatabaseAlways<LibraryContext>());
#endif
            #endregion
            using (var dbcontext = new LibraryContext())
            {
                
                dbcontext.Database.Initialize(false);
            }

        }

        

    }
}
