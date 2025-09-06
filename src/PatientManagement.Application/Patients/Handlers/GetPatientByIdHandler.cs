using Microsoft.Extensions.Logging;
using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Application.Patients.Queries;
using PatientManagement.Domain.Interfaces.Handlers;
using PatientManagement.Application.Mappers.Interfaces;
using PatientManagement.Domain.Interfaces.Repositories.Patients;


namespace PatientManagement.Application.Patients.Handlers;

public class GetPatientByIdHandler : IQueryHandler<GetPatientByIdQuery, Result<PatientDto>>
{
    private readonly IPatientRepository _repository;
    private readonly IPatientMapper _mapper;
    private readonly ILogger<GetPatientByIdHandler> _logger;
    public GetPatientByIdHandler(IPatientRepository repository, ILogger<GetPatientByIdHandler> logger, IPatientMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }
   
    public async Task<Result<PatientDto>> Handle(GetPatientByIdQuery query)
    {
        _logger.LogInformation("[GetPatientByIdHandler] Iniciando retorno de paciente: {Id}", query.Id);
        try
        {
            var paciente = await _repository.GetByIdAsync(query.Id);
            var dto = _mapper.ToDto(paciente);
            return Result<PatientDto>.Ok(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao pesquisar pacientes.");
            return Result<PatientDto>.Fail($"Erro ao pesquisar paciente: {ex.Message}");
        }
    }
}