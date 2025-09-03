using Microsoft.Extensions.DependencyInjection;
using PatientManagement.Application.Extensions.DependancyInjection;
using PatientManagement.Domain.Interfaces.Mediator;
using PatientManagement.Domain.Interfaces.Handlers;
using PatientManagement.Application.PatientApp.Commands;
using PatientManagement.Domain.Entities;
using PatientManagement.Application.PatientApp.Queries;
using PatientManagement.Application.PatientApp.Handlers;

namespace PatientManagement.Application.Extensions;

 public static class ApplicationExtension
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
        // services.AddScoped<CreatePatientHandler>();
        // services.AddScoped<GetPatientsHandler>();
            services.AddScoped<IMediator, Mediator>();
            services.AddScoped<ICommandHandler<CreatePatientCommand, Patient>, CreatePatientHandler>();
            services.AddScoped<ICommandHandler<UpdatePatientCommand, Patient>, UpdatePatientHandler>();
            services.AddScoped<ICommandHandler<DeletePatientCommand, bool>, DeletePatientHandler>();
            services.AddScoped<IQueryHandler<GetPatientsQuery, IEnumerable<Patient>>, GetPatientsHandler>();
            services.AddScoped<IQueryHandler<GetPatientByIdQuery, Patient>, GetPatientByIdHandler>();

            // registra todos os handlers automaticamente
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