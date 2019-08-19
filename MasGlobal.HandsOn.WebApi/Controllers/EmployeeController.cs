using MasGlobal.HandsOn.BL.Interface;
using MasGlobal.HandsOn.WebApi.Helpers;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Unity;

namespace MasGlobal.HandsOn.WebApi.Controllers
{

    /// <summary>
    /// Employee Api
    /// </summary>
    public class EmployeeController : ApiController
    {
        /// <summary>
        /// DEpendency Injection for Employee Service
        /// </summary>
        [Dependency]
        public IEmployeeService EmployeeService
        {
            get; set;
        }

        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.Route("api/Employee/GetAll")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var returnValue = EmployeeService.GetAll();
                return this.CreateSimpleResponse(System.Net.HttpStatusCode.OK, returnValue);
            }
            catch (Exception error)
            {
                return this.CreateErrorResponse(error);
            }
        }


        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.Route("api/Employee/GetAllExternal")]
        public async Task<HttpResponseMessage> GetAllExternal()
        {
            try
            {
                var returnValue = await EmployeeService.GetAllExternal();
                return this.CreateSimpleResponse(System.Net.HttpStatusCode.OK, returnValue);
            }
            catch (Exception error)
            {
                return this.CreateErrorResponse(error);
            }
        }

        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.Route("api/Employee/GetById")]
        public HttpResponseMessage GetById(int employeeId)
        {
            try
            {
                var returnValue = EmployeeService.GetById(employeeId);
                return this.CreateSimpleResponse(System.Net.HttpStatusCode.OK, returnValue);
            }
            catch (Exception error)
            {
                return this.CreateErrorResponse(error);
            }
        }

    }
}
