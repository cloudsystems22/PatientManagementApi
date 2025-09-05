using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using PatientManagement.Api.Middleware;
using PatientManagement.Application.Extensions;
using PatientManagement.Infrastructure.Data;
using PatientManagement.Infrastructure.Extensions;

namespace PatientManagement.Api;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {

        // services.AddDbContext<MSSQLDbContext>(options =>
        //     options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"),
        //         sqlOptions => sqlOptions.EnableRetryOnFailure(
        //                             maxRetryCount: 5,
        //                             maxRetryDelay: TimeSpan.FromSeconds(10),
        //                             errorNumbersToAdd: null
        //                         )
        //         )
        //     );

        services.AddDbContext<MSSQLDbContext>(options =>
           options.UseInMemoryDatabase("PatientDb"));


        // Configurar controllers
        services.AddRepositories();

        services.AddHandlers();

        services.AddControllers()
         .AddJsonOptions(options =>
         {
             options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
             options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
             options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
         });

        services.AddSwaggerGen();
        
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins",
                policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseCors("AllowAllOrigins");

        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Gerenciamento de Pacientes v1"));
            app.UseDeveloperExceptionPage();
        }

        app.UseGlobalExceptionHandling();

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthorization();
        app.UseAuthentication();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}