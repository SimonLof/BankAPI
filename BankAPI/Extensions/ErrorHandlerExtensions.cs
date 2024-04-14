using Microsoft.AspNetCore.Diagnostics;

namespace BankApp.API.Extensions
{
    public static class ErrorHandlerExtensions
    {
        public static IApplicationBuilder UserErrorHandlerExtensions(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature is not null)
                    {
                        // logga alla errors till en riktig log.
                        Console.WriteLine($"Error: {contextFeature.Error}");

                        await context.Response.WriteAsJsonAsync(new
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error"
                        });
                    }

                });
            });

            return app;
        }
    }
}
