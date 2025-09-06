using PatientManagement.Application.Dtos;
using PatientManagement.Application.Mappers.Interfaces;
using PatientManagement.Application.Triages.Commands;
using PatientManagement.Domain.Entities;

namespace PatientManagement.Application.Mappers;

public class TriageMapper : ITriageMapper
{
    public TriageDto ToDto(Triage triage)
    {
        return new TriageDto
        {
            Id = triage.Id,
            CareId = triage.CareId,
            Symptoms = triage.Symptoms,
            BloodPressure = triage.BloodPressure,
            Weight = triage.Weight,
            Height = triage.Height,
            SpecialtyId = triage.SpecialtyId,
            IMC = triage.IMC,
            IMCClassification = triage.IMCClassification
        };
    }

    public IEnumerable<TriageDto> ToDtoIEnumerable(IEnumerable<Triage> triages)
    {
        if (triages == null)
            return Enumerable.Empty<TriageDto>();

        return triages.Select(t => ToDto(t));
    }

    public Triage ToEntity(CreateTriageCommand command)
    {
        return new Triage
        {
            Id = command.Id,
            CareId = command.CareId,
            Symptoms = command.Symptoms,
            BloodPressure = command.BloodPressure,
            Weight = command.Weight,
            Height = command.Height,
            SpecialtyId = command.SpecialtyId,
        };
    }

    public Triage ToEntity(UpdateTriageCommand command)
    {
        return new Triage
        {
            Id = command.Id,
            Symptoms = command.Symptoms,
            BloodPressure = command.BloodPressure,
            Weight = command.Weight,
            Height = command.Height,
            SpecialtyId = command.SpecialtyId
        };
    }
}
