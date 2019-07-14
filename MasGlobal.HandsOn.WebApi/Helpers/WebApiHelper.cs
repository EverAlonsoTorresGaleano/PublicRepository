using MasGlobal.HandsOn.BL.Transverse;
using MasGlobal.HandsOn.Model.Enums;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;

namespace MasGlobal.HandsOn.WebApi.Helpers
{

    /// <summary>
    /// Helper to easy handle of web api
    /// </summary>
    public static class WebApiExtension
    {

        /// <summary>
        /// Create A Simple Reqsponse Message
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="httpStatusCode"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static HttpResponseMessage CreateSimpleResponse(this ApiController controller, HttpStatusCode httpStatusCode, object data)
        {
            var response = new HttpResponseMessage()
            {
                StatusCode = httpStatusCode,
            };

            if (data != null)
            {
                response.Content = new ObjectContent(data.GetType(), data,
                       new JsonMediaTypeFormatter(),
                       new MediaTypeWithQualityHeaderValue("application/json"));
            }
            return response;
        }

        /// <summary>
        /// Create Erro Response
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static HttpResponseMessage CreateErrorResponse(this ApiController controller, Exception exception)
        {
            LoggingService.LogException(exception, ExceptionPolicyEnum.ServiceLayer);
            var response = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.InternalServerError,
                ReasonPhrase = exception.Message

            };
            return response;
        }

        /// <summary>
        /// Get Internal information of exception
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        private static string GetFullExceptionInfo(this Exception exception)
        {
            StringBuilder erroMessage = new StringBuilder(exception.Message);
            Exception internalError = exception.InnerException;
            while (internalError != null)
            {
                erroMessage.Append(internalError.Message);
                internalError = exception.InnerException;
            }
            erroMessage.Append(exception.StackTrace);
            return erroMessage.ToString();

        }
    }
}