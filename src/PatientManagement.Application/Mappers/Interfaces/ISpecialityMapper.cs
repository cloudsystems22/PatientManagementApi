using PatientManagement.Application.Dtos;
using PatientManagement.Application.Specialities.Commands;
using PatientManagement.Domain.Entities;

namespace PatientManagement.Application.Mappers.Interfaces;

public interface ISpecialityMapper
{
    SpecialityDto ToDto(Speciality speciality);
    IEnumerable<SpecialityDto> ToDtoIEnumerable(IEnumerable<Speciality> specialities);
    Speciality ToEntity(CreateSpecialityCommand command);
    Speciality ToEntity(UpdateSpecialityCommand command);
}