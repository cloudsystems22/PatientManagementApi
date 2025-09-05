using Microsoft.Extensions.Logging;
using PatientManagement.Application.Common;
using PatientManagement.Application.PatientApp.Queries;
using PatientManagement.Domain.Entities;
using PatientManagement.Domain.Interfaces.Handlers;
using PatientManagement.Domain.Interfaces.Repositories.Patients;


namespace PatientManagement.Application.PatientApp.Handlers;

public class GetPatientByIdHandler : IQueryHandler<GetPatientByIdQuery, Result<Patient>>
{
    private readonly IPatientRepository _repository;
    private readonly ILogger<GetPatientByIdHandler> _logger;
    public GetPatientByIdHandler(IPatientRepository repository, ILogger<GetPatientByIdHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }
   
    public async Task<Result<Patient>> Handle(GetPatientByIdQuery query)
    {
        _logger.LogInformation("[GetPatientByIdHandler] Iniciando retorno de paciente: {Id}", query.Id);
        try
        {
            var paciente = await _repository.GetByIdAsync(query.Id);
            return Result<Patient>.Ok(paciente);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao pesquisar pacientes.");
            return Result<Patient>.Fail($"Erro ao pesquisar paciente: {ex.Message}");
        }
    }
}