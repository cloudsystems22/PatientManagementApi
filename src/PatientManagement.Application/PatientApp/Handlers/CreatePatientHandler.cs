using System.Net.Mail;
using Microsoft.Extensions.Logging;
using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Application.PatientApp.Commands;
using PatientManagement.Domain.Entities;
using PatientManagement.Domain.Interfaces.Handlers;
using PatientManagement.Domain.Interfaces.Mappers;
using PatientManagement.Domain.Interfaces.Repositories.Patients;

namespace PatientManagement.Application.PatientApp.Handlers;

public class CreatePatientHandler : ICommandHandler<CreatePatientCommand, Result<PatientDto>>
{
    private readonly IPatientRepository _repository;
    private readonly IPatientMapper _mapper;
    private readonly ILogger<CreatePatientHandler> _logger;

    public CreatePatientHandler(IPatientRepository repository, ILogger<CreatePatientHandler> logger, IPatientMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<Result<PatientDto>> Handle(CreatePatientCommand command)
    {
        _logger.LogInformation("[CreatePatientHandler] Iniciando criação de paciente: {Name}", command.Name);
        try
        {
            var entity = _mapper.ToEntity(command);
            await _repository.AddAsync(entity);
            var dto = _mapper.ToDto(entity);
            return Result<PatientDto>.Ok(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao criar paciente");
            return Result<PatientDto>.Fail($"Erro ao cadastrar paciente: {ex.Message}");
        }

    }
}
