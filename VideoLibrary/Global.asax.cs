using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using VideoLibrary.BusinessEntities;

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
            //Database.SetInitializer(new Init());
#endif
            #endregion
            using (var dbcontext = new LibraryContext())
            {
                dbcontext.Database.Initialize(false);
            }

        }

    }
}
