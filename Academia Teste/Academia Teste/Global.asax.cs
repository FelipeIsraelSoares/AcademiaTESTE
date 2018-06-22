using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Academia_Teste
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            System.Web.Helpers.AntiForgeryConfig.UniqueClaimTypeIdentifier = "Login";
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
        }
    }
}
