using System;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using PersonalWebsite.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace PersonalWebsite.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("BlogDatabase");

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });


            services.AddDbContext<BlogIdentityDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            }).AddIdentityCookies(options =>
            {
                options.ApplicationCookie.PostConfigure(o => throw new NotImplementedException());
            });

            return services;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseSession();

            return app;
        }
    }
}
