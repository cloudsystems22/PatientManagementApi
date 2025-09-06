using PatientManagement.Application.Dtos;
using PatientManagement.Application.Mappers.Interfaces;
using PatientManagement.Application.Specialities.Commands;
using PatientManagement.Domain.Entities;

namespace PatientManagement.Application.Mappers;

public class SpecialityMapper : ISpecialityMapper
{
    public SpecialityDto ToDto(Speciality speciality)
    {
        return new SpecialityDto
        {
            Id = speciality.Id,
            Name = speciality.Name
        };
    }

    public IEnumerable<SpecialityDto> ToDtoIEnumerable(IEnumerable<Speciality> specialities)
    {
        if (specialities == null)
            return Enumerable.Empty<SpecialityDto>();

        return specialities.Select(s => ToDto(s));
    }

   public Speciality ToEntity(CreateSpecialityCommand command)
    {
        return new Speciality
        {
            Id = command.Id,
            Name = command.Name
        };
    }

    public Speciality ToEntity(UpdateSpecialityCommand command)
    {
        return new Speciality
        {
            Id = command.Id,
            Name = command.Name
        };
    }
}