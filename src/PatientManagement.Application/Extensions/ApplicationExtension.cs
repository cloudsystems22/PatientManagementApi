using Microsoft.Extensions.DependencyInjection;
using PatientManagement.Application.PatientApp.Handlers;

namespace PatientManagement.Application.Extensions;

 public static class ApplicationExtension
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddScoped<CreatePatientHandler>();
            services.AddScoped<GetPatientsHandler>();
            return services;
        }
    }