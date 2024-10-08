using Infrastructure.Configuration;
using Infrastructure.Context;
using Serilog;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configura o Serilog para usar um arquivo de texto
        Log.Logger = new LoggerConfiguration()
            .WriteTo.File("Logs/log-data-.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
        
        builder.Host.UseSerilog();


        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        //builder.Services.AddAutoMapper(typeof(Map));


        // Register infrastructure services
        builder.Services.AddInfrastructure(builder.Configuration);



        var app = builder.Build();

        // Criar banco de dados
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();
            // DbInitializer.Initialize(context);
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}