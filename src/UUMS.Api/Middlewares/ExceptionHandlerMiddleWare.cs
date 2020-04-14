using Exceptionless;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace UUMS.Api.Middlewares
{
    public class ExceptionHandlerMiddleWare
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                ex.ToExceptionless().Submit();
                throw;
            }
        }
    }
}
