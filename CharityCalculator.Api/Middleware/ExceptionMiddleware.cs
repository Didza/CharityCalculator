using System;
using System.Net;
using System.Threading.Tasks;
using CharityCalculator.Application.Exceptions;
using CharityCalculator.Application.Responses;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CharityCalculator.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            var result = JsonConvert.SerializeObject(new ErrorDeatils
            {
                ErrorMessage = exception.Message,
                ErrorType = "Failure"
            });

            switch (exception)
            {
                case ValidationException validationException:
                    statusCode = HttpStatusCode.OK;
                    var response = new BaseResponse();
                    response.Success = false;
                    response.Message = "Creation Failed";
                    response.Errors = validationException.Errors;
                    result = JsonConvert.SerializeObject(response);
                    break;
                case NotFoundException notFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    break;
                default:
                    break;
            }

            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(result);
        }
    }

    public class ErrorDeatils
    {
        public string ErrorType { get; set; }
        public string ErrorMessage { get; set; }
    }
}
