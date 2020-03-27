using Application.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Middleware
{
    public class ErrorHadlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHadlingMiddleware> _logger;

        public ErrorHadlingMiddleware(RequestDelegate next, ILogger<ErrorHadlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HadleExceptionAsync(context, ex, _logger);
            }
        }
        private async Task HadleExceptionAsync(HttpContext context, Exception ex, ILogger<ErrorHadlingMiddleware> logger)
        {
            object errors = null;
            switch (ex)
            {
                case RestException re:
                    logger.LogError(ex, "REST ERROR");
                    errors = re.Errors;
                    context.Response.StatusCode = (int)re.Code;
                    break;
                case Exception e:
                    logger.LogError(ex, "SERVER ERROR");
                    errors = string.IsNullOrWhiteSpace(e.Message) ? "Error" : e.Message;
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    break;

            }

            context.Response.ContentType = "application/json";
            if (errors != null)
            {
                var json = JsonConvert.SerializeObject(errors);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
