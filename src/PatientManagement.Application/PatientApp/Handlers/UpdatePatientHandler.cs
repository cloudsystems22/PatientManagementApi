using Microsoft.Extensions.Logging;
using PatientManagement.Application.Common;
using PatientManagement.Application.PatientApp.Commands;
using PatientManagement.Domain.Entities;
using PatientManagement.Domain.Interfaces.Handlers;
using PatientManagement.Domain.Interfaces.Repositories.Patients;

namespace PatientManagement.Application.PatientApp.Handlers;

public class UpdatePatientHandler : ICommandHandler<UpdatePatientCommand, Result<Patient>>
{
    private readonly IPatientRepository _repository;
    private readonly ILogger<UpdatePatientHandler> _logger;

    public UpdatePatientHandler(IPatientRepository repository, ILogger<UpdatePatientHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }


    public async Task<Result<Patient>> Handle(UpdatePatientCommand command)
    {
        try
        {
            var patient = await _repository.GetByIdAsync(command.Id);

            if (patient == null)
                return Result<Patient>.Ok(patient!);

            patient.Rg = command.Rg;
            patient.Name = command.Name;
            patient.Phone = command.Phone;
            patient.Sex = command.Sex;
            patient.EmailAddress = command.EmailAddress;

            await _repository.UpdateAsync(patient);
            return Result<Patient>.Ok(patient);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao tentar atualizar dados de paciente.");
            return Result<Patient>.Fail($"Erro ao tentar atualizar dados de paciente. {ex.Message}");
        }
    }

}