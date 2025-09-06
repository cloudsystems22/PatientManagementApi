using Microsoft.Extensions.DependencyInjection;
using PatientManagement.Application.Extensions.DependancyInjection;
using PatientManagement.Domain.Interfaces.Mediator;
using PatientManagement.Domain.Interfaces.Handlers;
using PatientManagement.Application.PatientApp.Commands;
using PatientManagement.Domain.Entities;
using PatientManagement.Application.PatientApp.Queries;
using PatientManagement.Application.PatientApp.Handlers;
using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Application.PatientApp.Mappers;
using PatientManagement.Domain.Interfaces.Mappers;

namespace PatientManagement.Application.Extensions;

public static class ApplicationExtension
{
    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddScoped<IMediator, Mediator>();
        services.AddScoped<ICommandHandler<CreatePatientCommand, Result<PatientDto>>, CreatePatientHandler>();
        services.AddScoped<ICommandHandler<UpdatePatientCommand, Result<PatientDto>>, UpdatePatientHandler>();
        services.AddScoped<ICommandHandler<DeletePatientCommand, Result<PatientDto>>, DeletePatientHandler>();
        services.AddScoped<IQueryHandler<GetPatientsQuery, Result<IEnumerable<PatientDto>>>, GetPatientsHandler>();
        services.AddScoped<IQueryHandler<GetPatientByIdQuery, Result<PatientDto>>, GetPatientByIdHandler>();
        services.AddScoped<IQueryHandler<SearchPatientsQuery, Result<IEnumerable<PatientDto>>>, SearchPatientsHandler>();
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

    public static IServiceCollection AddMappers(this IServiceCollection services)
    {
        services.AddScoped<IPatientMapper, PatientMapper>();
        return services;
    }
    
}