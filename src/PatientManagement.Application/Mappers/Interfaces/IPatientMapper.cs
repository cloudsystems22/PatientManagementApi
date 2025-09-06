using PatientManagement.Application.Dtos;
using PatientManagement.Application.Patients.Commands;
using PatientManagement.Domain.Entities;

namespace PatientManagement.Application.Mappers.Interfaces;

public interface IPatientMapper
{
    Patient ToEntity(CreatePatientCommand command);
    Patient ToEntity(UpdatePatientCommand command);
    PatientDto ToDto(Patient patient);
    IEnumerable<PatientDto> ToDtoIEnumerable(IEnumerable<Patient> patients);
}
