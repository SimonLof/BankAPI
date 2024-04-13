using Microsoft.AspNetCore.Authentication.Cookies;

namespace BankApp.API.Extensions
{
    public static class CookieExtensions
    {

        public static IServiceCollection AddCookieExtended(this IServiceCollection services)
        {
            // identity ville redirecta till en login page som inte fanns, så alla errors med auth gav 404 istället för 401 och 403.
            services.ConfigureApplicationCookie(opt =>
            {
                opt.Events = new CookieAuthenticationEvents()
                {
                    OnRedirectToLogin = (context) =>
                    {
                        if (context.Response.StatusCode == 200)
                        {
                            context.Response.StatusCode = 401;
                        }

                        return Task.CompletedTask;
                    },
                    OnRedirectToAccessDenied = (context) =>
                    {
                        if (context.Response.StatusCode == 200)
                        {
                            context.Response.StatusCode = 403;
                        }

                        return Task.CompletedTask;
                    }
                };
            });

            return services;
        }
    }
}
