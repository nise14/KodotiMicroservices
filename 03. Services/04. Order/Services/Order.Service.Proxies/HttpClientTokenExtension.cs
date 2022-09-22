using Microsoft.AspNetCore.Http;

namespace Order.Service.Proxies;

public static class HttpClientTokenExtension
{
    public static void AddBearerToken(this HttpClient client, IHttpContextAccessor context)
    {
        if (context.HttpContext.User.Identity.IsAuthenticated
            && context.HttpContext.Request.Headers.ContainsKey("Authorization"))
        {
            string token = context.HttpContext.Request.Headers["Authorization"].ToString();
            if (!string.IsNullOrWhiteSpace(token))
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", token);
            }
        }
    }
}