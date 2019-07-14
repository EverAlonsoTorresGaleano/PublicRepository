using MasGlobal.HandsOn.BL.Implemetation;
using MasGlobal.HandsOn.BL.Interface;
using MasGlobal.HandsOn.Repository.Implementation;
using MasGlobal.HandsOn.Repository.Interface;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace MasGlobal.HandsOn.View.Web
{
    /// <summary>
    /// Handle of Dependenci injection
    /// </summary>
    public static class UnityConfig
    {
        /// <summary>
        /// Register Componenets for Dependency Injection
        /// </summary>
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IEmployeeRepository, EmployeeRepository>();
            container.RegisterType<IEmployeeService, EmployeeService>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}