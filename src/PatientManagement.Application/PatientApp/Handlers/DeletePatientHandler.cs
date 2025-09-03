using PatientManagement.Application.PatientApp.Commands;
using PatientManagement.Domain.Interfaces.Handlers;
using PatientManagement.Domain.Interfaces.Repositories.Patients;

namespace PatientManagement.Application.PatientApp.Handlers;

public class DeletePatientHandler : ICommandHandler<DeletePatientCommand, bool>
{
    private readonly IPatientRepository _repository;

    public DeletePatientHandler(IPatientRepository repository)
        => _repository = repository;


    public async Task<bool> Handle(DeletePatientCommand command)
    {
        var patient = await _repository.GetByIdAsync(command.Id);
        if (patient == null)
            return false;

        await _repository.RemoveAsync(patient);
        return true;
    }
}