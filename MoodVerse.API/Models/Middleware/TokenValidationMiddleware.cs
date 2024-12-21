using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

public class TokenValidationMiddleware
{
    private RequestDelegate Request { get; }

    public TokenValidationMiddleware(RequestDelegate request)
    {
        Request = request;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (IsRequestAnonymous(context))
        {
            await Request(context);
            return;
        }

        var accessToken = context.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();

        if (string.IsNullOrEmpty(accessToken))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return;
        }

        if (!IsAccessTokenValid(accessToken))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return;
        }

        await Request(context);
    }

    private static bool IsRequestAnonymous(HttpContext context)
    {
        var endpoint = context.GetEndpoint();
        return endpoint?.Metadata.GetMetadata<AllowAnonymousAttribute>() != null;
    }

    private static bool IsAccessTokenValid(string token)
    {
        if (string.IsNullOrEmpty(token)) return false;

        var handler = new JwtSecurityTokenHandler();
        if (!handler.CanReadToken(token)) return false;

        var jwtToken = handler.ReadJwtToken(token);
        return jwtToken.ValidTo > DateTime.UtcNow;
    }
}