using Microsoft.Extensions.DependencyInjection;
using PatientManagement.Domain.Interfaces.Repositories.Patients;
using PatientManagement.Infrastructure.Repositories;

namespace PatientManagement.Infrastructure.Extensions;

public static class RepositoriesExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPatientRepository, PatientRepository>();
            return services;
        }
    } 