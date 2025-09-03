using PatientManagement.Application.PatientApp.Commands;
using PatientManagement.Domain.Entities;
using PatientManagement.Domain.Interfaces.Handlers;
using PatientManagement.Domain.Interfaces.Repositories.Patients;

namespace PatientManagement.Application.PatientApp.Handlers;

public class CreatePatientHandler : ICommandHandler<CreatePatientCommand, Patient>
{
    private readonly IPatientRepository _repository;

    public CreatePatientHandler(IPatientRepository repository)
        => _repository = repository;

    public async Task<Patient> Handle(CreatePatientCommand command)
    {
        var paciente = new Patient
        {
            Id = command.Id,
            Name = command.Name,
            Phone = command.Phone,
            Sex = command.Sex,
            EmailAdress = command.EmailAdress
        };

        await _repository.AddAsync(paciente);
        return paciente;
    }

}
