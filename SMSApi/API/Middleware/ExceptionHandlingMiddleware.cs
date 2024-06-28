using static SMSApi.Domain.Exceptions.Exceptions;
using System.Net;
using SMSApi.Domain.Exceptions;
using Serilog;

namespace SMSApi.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = ex switch
            {
                InvalidPhoneNumberException => CustomStatusCodes.INVALID_PHONE_NUMBER,
                MessageTooLongException => CustomStatusCodes.MESSAGE_TOO_LONG,
                EmptyMessageException => CustomStatusCodes.EMPTY_MESSAGE,
                MessageContainsProhibitedWordsException => CustomStatusCodes.MESSAGE_CONTAINS_PROHIBITED_WORDS,
                SMSProviderException => CustomStatusCodes.SMS_PROVIDER_EXCPETION,
                _ => (int)HttpStatusCode.InternalServerError,
            };

            var response = new
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message
            };

            Log.Error(ex, "ExceptionHandlingMiddleware");

            return context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));
        }
    }
}
