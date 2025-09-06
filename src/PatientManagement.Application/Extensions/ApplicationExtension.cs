using Microsoft.Extensions.DependencyInjection;
using PatientManagement.Application.Extensions.DependancyInjection;
using PatientManagement.Domain.Interfaces.Mediator;
using PatientManagement.Domain.Interfaces.Handlers;
using PatientManagement.Application.Patients.Commands;
using PatientManagement.Application.Patients.Queries;
using PatientManagement.Application.Patients.Handlers;
using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Application.Mappers.Interfaces;
using PatientManagement.Application.Mappers;
using PatientManagement.Application.Specialities.Commands;
using PatientManagement.Application.Specialities.Queries;
using PatientManagement.Application.Specialities.Handlers;
using PatientManagement.Application.Cares.Commands;
using PatientManagement.Application.Cares.Handlers;
using PatientManagement.Application.Triages.Commands;
using PatientManagement.Application.Triages.Handlers;
using PatientManagement.Application.Cares.Queries;
using PatientManagement.Application.Triages.Queries;

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
    
        // Speciality Handlers
        services.AddScoped<ICommandHandler<CreateSpecialityCommand, Result<SpecialityDto>>, CreateSpecialityHandler>();
        services.AddScoped<ICommandHandler<UpdateSpecialityCommand, Result<SpecialityDto>>, UpdateSpecialityHandler>();
        services.AddScoped<ICommandHandler<DeleteSpecialityCommand, Result<SpecialityDto>>, DeleteSpecialityHandler>();
        services.AddScoped<IQueryHandler<GetSpecialitiesQuery, Result<IEnumerable<SpecialityDto>>>, GetSpecialitiesHandler>();
        services.AddScoped<IQueryHandler<GetSpecialityByIdQuery, Result<SpecialityDto>>, GetSpecialityByIdHandler>();
        services.AddScoped<IQueryHandler<SearchSpecialityQuery, Result<IEnumerable<SpecialityDto>>>, SearchSpecialityHandler>();

        // Care Handlers
        services.AddScoped<ICommandHandler<CreateCareCommand, Result<CareDto>>, CreateCareHandler>();
        services.AddScoped<ICommandHandler<UpdateCareCommand, Result<CareDto>>, UpdateCareHandler>();
        services.AddScoped<ICommandHandler<DeleteCareCommand, Result<CareDto>>, DeleteCareHandler>();
        services.AddScoped<IQueryHandler<GetCareByIdQuery, Result<CareDto>>, GetCareByIdHandler>();
        services.AddScoped<IQueryHandler<SearchCareQuery, Result<IEnumerable<CareDto>>>, SearchCareHandler>();

        // Triage Handlers
        services.AddScoped<ICommandHandler<CreateTriageCommand, Result<TriageDto>>, CreateTriageHandler>();
        services.AddScoped<ICommandHandler<UpdateTriageCommand, Result<TriageDto>>, UpdateTriageHandler>();
        services.AddScoped<ICommandHandler<DeleteTriageCommand, Result<TriageDto>>, DeleteTriageHandler>();
        services.AddScoped<IQueryHandler<GetTriageByIdQuery, Result<TriageDto>>, GetTriageByIdHandler>();
        services.AddScoped<IQueryHandler<SearchTriageQuery, Result<IEnumerable<TriageDto>>>, SearchTriageHandler>();
    
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
        services.AddScoped<ISpecialityMapper, SpecialityMapper>();
        services.AddScoped<ICareMapper, CareMapper>();
        services.AddScoped<ITriageMapper, TriageMapper>();
        return services;
    }
    
}