using System.Web;
using System.Web.Mvc;

using System.Web.Routing;
namespace ChemAnalyst.Authorize
{
    public class AuthorizationPrivilegeFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            // AuthorizationService _authorizeService = new AuthorizationService();
            //context.HttpContext.Session.Contents["ID"];
            string userId = filterContext.HttpContext.Session.Contents["User"].ToString();
            if (userId != null)
            {
              //  var result = _authorizeService.CanManageUser(userId);
                //if (!result)
                //{
                //    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary{{ "controller", "Account" },
                //                          { "action", "Login" }

                //                         });
                //}
                
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary{{ "controller", "ChemAnalystController" },
                                          { "action", "Index" }

                                         });

            }
            base.OnActionExecuting(filterContext);
        }

    }
}