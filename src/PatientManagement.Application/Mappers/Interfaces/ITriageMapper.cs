using PatientManagement.Application.Dtos;
using PatientManagement.Application.Triages.Commands;
using PatientManagement.Domain.Entities;

namespace PatientManagement.Application.Mappers.Interfaces;

public interface ITriageMapper
{
    TriageDto ToDto(Triage triage);
    IEnumerable<TriageDto> ToDtoIEnumerable(IEnumerable<Triage> triages);
    Triage ToEntity(CreateTriageCommand command);
    Triage ToEntity(UpdateTriageCommand command);
}
