using PatientManagement.Application.PatientApp.Commands;
using PatientManagement.Domain.Repositories;
using PatientManagement.Domain.Entities;

namespace PatientManagement.Application.PatientApp.Handlers;

public class CreatePatientHandler
{
    private readonly IPatientRepository _repository;

    public CreatePatientHandler(IPatientRepository repository)
        => _repository = repository;

    public async Task<Patient> Handle(CreatePatientCommand command)
    {
        var paciente = new Patient
        {
            Name = command.Name,
            Phone = command.Phone,
            Sex = command.Sex,
            EmailAdress = command.EmailAdress
        };

        await _repository.AddAsync(paciente);
        return paciente;
    }
}