using Microsoft.Extensions.Logging;
using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Application.Patients.Commands;
using PatientManagement.Domain.Interfaces.Handlers;
using PatientManagement.Application.Mappers.Interfaces;
using PatientManagement.Domain.Interfaces.Repositories.Patients;

namespace PatientManagement.Application.Patients.Handlers;

public class UpdatePatientHandler : ICommandHandler<UpdatePatientCommand, Result<PatientDto>>
{
    private readonly IPatientRepository _repository;
    private readonly IPatientMapper _mapper;
    private readonly ILogger<UpdatePatientHandler> _logger;

    public UpdatePatientHandler(IPatientRepository repository, ILogger<UpdatePatientHandler> logger, IPatientMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }


    public async Task<Result<PatientDto>> Handle(UpdatePatientCommand command)
    {
        try
        {
            var patient = await _repository.GetByIdAsync(command.Id);

            if (patient == null)
                return Result<PatientDto>.Ok(new PatientDto());

            patient.Rg = command.Rg;
            patient.Name = command.Name;
            patient.Phone = command.Phone;
            patient.Sex = command.Sex;
            patient.EmailAddress = command.EmailAddress;

            await _repository.UpdateAsync(patient);
            var dto = _mapper.ToDto(patient);
            return Result<PatientDto>.Ok(dto);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao tentar atualizar dados de paciente.");
            return Result<PatientDto>.Fail($"Erro ao tentar atualizar dados de paciente. {ex.Message}");
        }
    }

}