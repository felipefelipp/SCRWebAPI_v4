using Domain.Services;
using Domain.Services.Interfaces;
using Infrastructure.Context;
using Infrastructure.Mapping;
using Infrastructure.Repositories.Interfaces;
using Infrastructure.Repositories.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configuration
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure Entity Framework
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("SCRWebAPI_v4.Api")));

            // Register Dapper context
            services.AddScoped<DapperContext>();

            // Register AutoMapper
            services.AddAutoMapper(typeof(MappingProfile));

            // Register application services
            services.AddApplicationServices();

            //Register Filters
           // services.AddScoped<ApiLoggingFilter>();


            return services;
        }

        public static void AddApplicationServices(this IServiceCollection services)
        {
            // Register generic repository
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Register specific repositories
            services.AddScoped<IPacienteRepository, PacienteRepository>();

            // Register other services here
             services.AddScoped<IPacienteService, PacienteService>();
        }
    }
}
