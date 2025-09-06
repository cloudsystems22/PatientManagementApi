using PatientManagement.Application.Dtos;
using PatientManagement.Application.Patients.Commands;
using PatientManagement.Domain.Entities;
using PatientManagement.Application.Mappers.Interfaces;

namespace PatientManagement.Application.Mappers
{
    public class PatientMapper : IPatientMapper
    {
        public Patient ToEntity(CreatePatientCommand command)
        {
            return new Patient
            {
                Id = command.Id,
                Rg = command.Rg,
                Name = command.Name,
                Phone = command.Phone,
                Sex = command.Sex,
                EmailAddress = command.EmailAddress
            };
        }

        public Patient ToEntity(UpdatePatientCommand command)
        {
            return new Patient
            {
                Id = command.Id,
                Rg = command.Rg,
                Name = command.Name,
                Phone = command.Phone,
                Sex = command.Sex,
                EmailAddress = command.EmailAddress
            };
        }

        public PatientDto ToDto(Patient patient)
        {
            return new PatientDto
            {
                Id = patient.Id,
                Rg = patient.Rg,
                Name = patient.Name,
                Phone = patient.Phone,
                Sex = patient.Sex,
                EmailAddress = patient.EmailAddress
            };
        }

        public IEnumerable<PatientDto> ToDtoIEnumerable(IEnumerable<Patient> patients)
        {
            if (patients == null) 
                return Enumerable.Empty<PatientDto>();

            return patients.Select(p => ToDto(p));
        }
    }
}
