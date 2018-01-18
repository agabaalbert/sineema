using System.Web.Mvc;
using VideoLibrary.Filters;

namespace VideoLibrary
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ValidateAttribute());
        }
    }
}
