using System.Web.Mvc;

namespace VideoLibrary.Filters
{
    public class ValidateAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var viewData = filterContext.Controller.ViewData;

            if (!viewData.ModelState.IsValid)
            {
                filterContext.Result = new ViewResult
                {
                    ViewData = viewData,
                    TempData = filterContext.Controller.TempData
                };
            }


            base.OnActionExecuting(filterContext);
        }
    }
}