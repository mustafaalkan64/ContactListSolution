using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SeturContactList.Core.Dtos;
using SeturContactList.Service.Exceptions;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace SeturContactListApi.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
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
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case ClientSideException e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case NotFoundExcepiton e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                _logger.LogError(error.Message);
                context.Response.StatusCode = response.StatusCode;
                var resp = CustomResponseDto<NoContentDto>.Fail(response.StatusCode, error.Message);
                await context.Response.WriteAsync(JsonSerializer.Serialize(resp));

            }
        }
    }
}
