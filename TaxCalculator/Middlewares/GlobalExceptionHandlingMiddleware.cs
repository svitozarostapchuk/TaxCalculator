namespace TaxCalculator.API.Middlewares
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

        public GlobalExceptionHandlingMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleware> logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                if (context.RequestAborted.IsCancellationRequested)
                {
                    _logger.LogInformation($"Request \"{context.Request.Path}\" has been canceled.");

                    return;
                }

                _logger.LogError(exception.Message);
                throw GetInnerException(exception) ?? new ApplicationException("Unhandled exception");
            }
        }

        public static Exception GetInnerException(Exception exception)
        {
            if (exception == null)
            {
                return null;
            }

            if (exception.InnerException == null)
            {
                return exception;
            }

            return GetInnerException(exception.InnerException);
        }
    }
}
