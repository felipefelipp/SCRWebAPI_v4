using Domain.Services;
using Domain.Services.Interfaces;
using Infrastructure.Context;
using Infrastructure.Repositories.Interfaces;
using Infrastructure.Repositories.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SCRWebAPI_v4.Domain.Mapping;
using SCRWebAPI_v4.Domain.Repositories.Interfaces;
using SCRWebAPI_v4.Domain.Services;
using SCRWebAPI_v4.Domain.Services.Interfaces;
using SCRWebAPI_v4.Infrastructure.Repositories.SqlServer;

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
            services.AddAutoMapper(typeof(Map));

            // Register application services
            services.AddApplicationServices();

            //Register Logging
            services.AddLogging();

            return services;
        }

        public static void AddApplicationServices(this IServiceCollection services)
        {

            // Register specific repositories
            services.AddScoped<IPacienteRepository, PacienteRepository>();
            services.AddScoped<IAtendimentoRepository, AtendimentoRepository>();
            services.AddScoped<IPerguntaRepository, PerguntaRepository>();
            services.AddScoped<IRespostaRepository, RespostaRepository>();

            // Register other services here
            services.AddScoped<IPacienteService, PacienteService>();
            services.AddScoped<IAtendimentoService, AtendimentoService>();
            services.AddScoped<IPerguntaService, PerguntaService>();
            services.AddScoped<IRespostaService, RespostaService>();
        }
    }
}
