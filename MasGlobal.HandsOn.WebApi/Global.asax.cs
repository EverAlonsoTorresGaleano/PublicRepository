using MasGlobal.HandsOn.BL.Transverse;
using MasGlobal.HandsOn.View.Web;
using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace MasGlobal.HandsOn.WebApi
{
    /// <summary>
    /// Handles Aplication Events
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// DEfine Service and Component at app start
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            UnityConfig.RegisterComponents();
            LoggingService.LogInformation("Application Started", Model.Enums.LoggingCategoryEnum.View);
            LoggingService.LogException(new Exception("This Exception Is Only For Test Exception Handling Logging"), Model.Enums.ExceptionPolicyEnum.View);
        }
    }
}
