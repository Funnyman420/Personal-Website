using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



namespace PersonalWebsite.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("BlogDatabase");

            services.AddDbContext<PersonalWebsiteDbContext>(options =>
            {
                options.UseMySQL(connectionString);
            });


            return services;
        }
    }
}
