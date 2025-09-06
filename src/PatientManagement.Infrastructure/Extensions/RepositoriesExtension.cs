using Microsoft.Extensions.DependencyInjection;
using PatientManagement.Domain.Interfaces.Repositories.Cares;
using PatientManagement.Domain.Interfaces.Repositories.Patients;
using PatientManagement.Domain.Interfaces.Repositories.Specialities;
using PatientManagement.Infrastructure.Repositories;

namespace PatientManagement.Infrastructure.Extensions;

public static class RepositoriesExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<ISpecialityRepository, SpecialityRepository>();
            services.AddScoped<ICareRepository, CareRepository>();
            return services;
        }
    } 