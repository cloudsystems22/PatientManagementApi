using PatientManagement.Application.Dtos;
using PatientManagement.Application.Cares.Commands;
using PatientManagement.Domain.Entities;
using PatientManagement.Application.Mappers.Interfaces;

namespace PatientManagement.Application.Mappers
{
    public class CareMapper : ICareMapper
    {
        public Care ToEntity(CreateCareCommand command)
        {
            return new Care
            {
                Id = command.Id,
                SequenceNumber = command.SequenceNumber,
                PatientId = command.PatientId,
                ArrivalTime = command.ArrivalTime,
                Status = command.Status
            };
        }

        public Care ToEntity(UpdateCareCommand command)
        {
            return new Care
            {
                Id = command.Id,
                SequenceNumber = command.SequenceNumber,
                PatientId = command.PatientId,
                ArrivalTime = command.ArrivalTime,
                Status = command.Status
            };
        }

        public CareDto ToDto(Care care)
        {
            return new CareDto
            {
                Id = care.Id,
                SequenceNumber = care.SequenceNumber,
                PatientId = care.PatientId,
                ArrivalTime = care.ArrivalTime,
                Status = care.Status
            };
        }

        public IEnumerable<CareDto> ToDtoIEnumerable(IEnumerable<Care> cares)
        {
            if (cares == null)
                return Enumerable.Empty<CareDto>();

            return cares.Select(c => ToDto(c));
        }
    }
}