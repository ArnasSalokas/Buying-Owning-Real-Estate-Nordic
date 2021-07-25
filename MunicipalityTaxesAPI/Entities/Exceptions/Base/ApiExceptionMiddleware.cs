using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Core.Extensions;

namespace Core.Exceptions.Base
{
    public class ApiExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            // Database logging could be done foe any exceptions that are caught
            try
            {
                await _next(context);
            }
            // Catches expected errors, that are thrown
            catch (MunicipalitiesException ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;

                SetResponseBody(context, new ApiErrorResponse
                {
                    Code = Convert.ToInt32(ex.Code),
                    Message = ex.Message,
                    ExceptionMessage = ex.ExceptionMessage, // This value should be used for DB logging, but for simplicity is returned instead
                    StackTrace = ex.StackTrace // This value should be used for DB logging, but for simplicity is returned instead
                });
            }
            // Catches unexpected errors that may arise 
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                SetResponseBody(context,  new ApiErrorResponse
                {
                    Code = (int)MunicipalitiesExceptionCodes.Base.UnknownError,
                    Message = MunicipalitiesExceptionCodes.Base.UnknownError.GetDescription()
                });
            }
        }
        private void SetResponseBody(HttpContext context, ApiErrorResponse response)
        {
            var json = JsonConvert.SerializeObject(response);
            using (var streamWriter = new StreamWriter(context.Response.Body))
            {
                streamWriter.Write(json);
            }
        }
    }
}