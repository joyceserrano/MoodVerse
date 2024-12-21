public static class HttpResponseExtensions
{
    public static void SetSecureCookie(this HttpResponse response, string key, string value, int daysToExpire = 1)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTime.UtcNow.AddDays(daysToExpire)
        };

        response.Cookies.Append(key, value, cookieOptions);
    }
}