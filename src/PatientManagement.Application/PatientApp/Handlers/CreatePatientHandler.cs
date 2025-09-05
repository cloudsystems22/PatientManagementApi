using System.Net.Mail;
using Microsoft.Extensions.Logging;
using PatientManagement.Application.Common;
using PatientManagement.Application.PatientApp.Commands;
using PatientManagement.Domain.Entities;
using PatientManagement.Domain.Interfaces.Handlers;
using PatientManagement.Domain.Interfaces.Repositories.Patients;

namespace PatientManagement.Application.PatientApp.Handlers;

public class CreatePatientHandler : ICommandHandler<CreatePatientCommand, Result<Patient>>
{
    private readonly IPatientRepository _repository;
    private readonly ILogger<CreatePatientHandler> _logger;

    public CreatePatientHandler(IPatientRepository repository, ILogger<CreatePatientHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<Result<Patient>> Handle(CreatePatientCommand command)
    {
        _logger.LogInformation("[CreatePatientHandler] Iniciando criação de paciente: {Name}", command.Name);
        try
        {
            var paciente = new Patient
            {
                Id = command.Id,
                Rg = command.Rg,
                Name = command.Name,
                Phone = command.Phone,
                Sex = command.Sex,
                EmailAddress = command.EmailAddress
            };

            await _repository.AddAsync(paciente);
            return Result<Patient>.Ok(paciente);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao criar paciente");
            return Result<Patient>.Fail($"Erro ao cadastrar paciente: {ex.Message}");
        }

    }
}
