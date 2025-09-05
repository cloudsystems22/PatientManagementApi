using Microsoft.Extensions.DependencyInjection;
using PatientManagement.Application.Extensions.DependancyInjection;
using PatientManagement.Domain.Interfaces.Mediator;
using PatientManagement.Domain.Interfaces.Handlers;
using PatientManagement.Application.PatientApp.Commands;
using PatientManagement.Domain.Entities;
using PatientManagement.Application.PatientApp.Queries;
using PatientManagement.Application.PatientApp.Handlers;
using PatientManagement.Application.Common;

namespace PatientManagement.Application.Extensions;

 public static class ApplicationExtension
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {

            services.AddScoped<IMediator, Mediator>();
            services.AddScoped<ICommandHandler<CreatePatientCommand, Result<Patient>>, CreatePatientHandler>();
            services.AddScoped<ICommandHandler<UpdatePatientCommand, Result<Patient>>, UpdatePatientHandler>();
            services.AddScoped<ICommandHandler<DeletePatientCommand, Result<Patient>>, DeletePatientHandler>();
            services.AddScoped<IQueryHandler<GetPatientsQuery, Result<IEnumerable<Patient>>>, GetPatientsHandler>();
            services.AddScoped<IQueryHandler<GetPatientByIdQuery, Result<Patient>>, GetPatientByIdHandler>();
            services.AddScoped<IQueryHandler<SearchPatientsQuery, Result<IEnumerable<Patient>>>, SearchPatientsHandler>();

            services.Scan(scan => scan
                .FromAssembliesOf(typeof(IMediator))
                .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<,>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
                .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
            );

            return services;
        }
    }