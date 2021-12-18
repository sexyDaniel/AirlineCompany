using Microsoft.AspNetCore.Http;
using System;
using FluentValidation;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using AirlineCompany.Application.Common;

namespace AirlineCompany.WebApi.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next) =>
            _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                await HandleExceptionAsync(context, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var errors = new List<Error>();
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;
            switch (exception)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    foreach (var f in validationException.Errors) 
                    {
                        errors.Add(new Error 
                        {
                            Text = f.ErrorMessage
                        });
                    }
                    result = JsonSerializer.Serialize(errors);
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (result == string.Empty)
            {
                result = JsonSerializer.Serialize(new { errpr = exception.Message });
            }

            return context.Response.WriteAsync(result);
        }
    }
}
