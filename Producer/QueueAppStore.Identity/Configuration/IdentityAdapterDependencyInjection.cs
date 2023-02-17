using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NetDevPack.Identity.Jwt;
using QueueAppStore.Domain.Adapters;
using QueueAppStore.Identity;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IdentityAdapterDependencyInjection
    {

        public static IServiceCollection AddIdentityAdapter(
           this IServiceCollection services,
           IConfiguration configuration)
        {
            //services.AddIdentityEntityFrameworkContextConfiguration(
            //    configuration,
            //    "QueueAppStore.IdentityAdapter.Configuration",
            //    "SqlConnectionString");

            services.AddIdentityEntityFrameworkContextConfiguration(options =>
                    options.UseSqlServer(configuration.GetSection("SqlAdapterConfiguration")["SqlConnectionString"],
                    b => b.MigrationsAssembly("AspNetCore.Jwt.Sample")));

            services.AddJwtConfiguration(configuration, "JwtAppSttings");

            services.AddIdentityConfiguration();

            services.AddScoped<IIdentityAdapter, IdentityAdapter>();

            return services;
        }
    }
}
