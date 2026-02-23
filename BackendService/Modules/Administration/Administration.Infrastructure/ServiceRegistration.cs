using Administration.Application.Authentication;
using Administration.Application.Mappers;
using Administration.Application.Service.Implementation;
using Administration.Application.Service.Interface;
using Administration.Domain.Interfaces;
using Administration.Infrastructure.ExternalServices;
using Administration.Infrastructure.Persistence;
using Administration.Infrastructure.Persistence.Repository;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Administration.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register infrastructure services here
            services.AddDbContext<bookmatrixdbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("bookmatrixdb")));

            services.AddScoped<IAdministrationRepository, AdministrationRepository>();

            services.AddScoped<IAdministrationAppService, AdministrationAppService>();

            //services.Configure<JwtSettings>(configuration["JwtSettings"]);

            services.AddScoped<ITokenService, TokenService>();

            //Mapping
            var config = new TypeAdapterConfig();
            config.Scan(typeof(MappingConfig).Assembly);
            services.AddSingleton(config);
            services.AddScoped<IMapper, Mapper>();
        }
    }
}
