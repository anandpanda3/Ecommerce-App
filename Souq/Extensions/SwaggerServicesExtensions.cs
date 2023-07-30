﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Souq.Extensions
{
    public static class SwaggerServicesExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services) {
            services.AddSwaggerGen(c =>
               c.SwaggerDoc("v1",
               new Microsoft.OpenApi.Models.OpenApiInfo
               {
                   Title = "Souq Api",
                   Version = "v1"
               })
           );
            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SKiNet API v1");
            });

            return app;
        }
    }
}
