using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;

namespace ChemAnalyst
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);


        }

        void Application_Error(object sender, EventArgs e)
        {
           // Exception ex = this.Server.GetLastError().GetBaseException();
           //// MyEventLog.LogException(ex); //Log the error in the Event Log!
           //                              //
           // FormsAuthentication.SignOut();
           // this.Response.Redirect("~/Login/index");//Here you can change with your URL!
        }
    }
}