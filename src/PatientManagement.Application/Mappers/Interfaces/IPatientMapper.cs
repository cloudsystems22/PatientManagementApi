using PatientManagement.Application.Dtos;
using PatientManagement.Application.PatientApp.Commands;
using PatientManagement.Domain.Entities;

namespace PatientManagement.Domain.Interfaces.Mappers
{
    public interface IPatientMapper
    {
        Patient ToEntity(CreatePatientCommand command);
        Patient ToEntity(UpdatePatientCommand command);
        PatientDto ToDto(Patient patient);
        IEnumerable<PatientDto> ToDtoIEnumerable(IEnumerable<Patient> patients);
    }
}
