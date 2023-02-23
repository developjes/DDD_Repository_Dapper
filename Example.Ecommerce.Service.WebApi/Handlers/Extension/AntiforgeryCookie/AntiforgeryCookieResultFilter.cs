using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Example.Ecommerce.Service.WebApi.Handlers.Extension.AntiforgeryCookie
{
    public class AntiforgeryCookieResultFilter : ResultFilterAttribute
    {
        private IAntiforgery _antiforgery;
        public AntiforgeryCookieResultFilter(IAntiforgery antiforgery) => _antiforgery = antiforgery;

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ViewResult)
            {
                AntiforgeryTokenSet tokens = _antiforgery.GetAndStoreTokens(context.HttpContext);
                context.HttpContext.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken!, new CookieOptions() { HttpOnly = false });
            }
        }
    }
}
