using Microsoft.Extensions.Logging;
using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Application.Patients.Queries;
using PatientManagement.Domain.Interfaces.Handlers;
using PatientManagement.Application.Mappers.Interfaces;
using PatientManagement.Domain.Interfaces.Repositories.Patients;

namespace PatientManagement.Application.Patients.Handlers;

public class GetPatientsHandler : IQueryHandler<GetPatientsQuery, Result<IEnumerable<PatientDto>>>
{
    private readonly IPatientRepository _repository;
    private readonly IPatientMapper _mapper;
    private readonly ILogger<GetPatientsHandler> _logger;
    public GetPatientsHandler(IPatientRepository repository, ILogger<GetPatientsHandler> logger, IPatientMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }
    
    public async Task<Result<IEnumerable<PatientDto>>> Handle(GetPatientsQuery query)
    {
        _logger.LogInformation("[GetPatientsHandler] Iniciando retorno de pacientes.");
        try
        {
            var pacientes = await _repository.GetAllAsync();
            var dto = _mapper.ToDtoIEnumerable(pacientes);
            return Result<IEnumerable<PatientDto>>.Ok(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao tentar retornar uma lista de pacientes");
            return Result<IEnumerable<PatientDto>>.Fail($"Erro ao tentar retornar uma lista de pacientes: {ex.Message}");
        }
    }

}