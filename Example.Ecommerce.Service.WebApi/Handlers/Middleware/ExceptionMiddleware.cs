namespace Example.Ecommerce.Service.WebApi.Handlers.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ExceptionMiddleware(RequestDelegate next, IServiceScopeFactory serviceScopeFactory) =>
            (_next, _serviceScopeFactory) = (next, serviceScopeFactory);

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                // implementar la seguridad de antiforgery:
                //https://www.dotnetcurry.com/aspnet/1343/aspnet-core-csrf-antiforgery-token
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(httpContext, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            /*
            using (IServiceScope scope = _serviceScopeFactory.CreateScope())
            {
                DapperContext dbContext = scope.ServiceProvider.GetService<DapperContext>();
            }
            */
            throw new ArgumentException(exception.Message, exception);
        }
    }
}
