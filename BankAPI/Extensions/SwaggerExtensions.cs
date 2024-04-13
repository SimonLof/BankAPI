namespace BankApp.API.Extensions
{
    public static class SwaggerExtensions
    {
        public static IApplicationBuilder UseSwaggerExtensions(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            return app;
        }

        public static IServiceCollection AddSwaggerExtended(this IServiceCollection services)
        {
            services.AddSwaggerGen();

            return services;
        }
    }
}
