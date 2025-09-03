using PatientManagement.Application.PatientApp.Commands;
using PatientManagement.Domain.Entities;
using PatientManagement.Domain.Interfaces.Handlers;
using PatientManagement.Domain.Interfaces.Repositories.Patients;

namespace PatientManagement.Application.PatientApp.Handlers;

public class UpdatePatientHandler : ICommandHandler<UpdatePatientCommand, Patient>
{
    private readonly IPatientRepository _repository;

    public UpdatePatientHandler(IPatientRepository repository)
        => _repository = repository;


    public async Task<Patient> Handle(UpdatePatientCommand command)
    {
        var patient = await _repository.GetByIdAsync(command.Id);

        if (patient == null)
            return null;

        patient.Name = command.Name;
        patient.Phone = command.Phone;
        patient.Sex = command.Sex;
        patient.EmailAdress = command.EmailAdress;

        await _repository.UpdateAsync(patient);
        return patient;
    }

}