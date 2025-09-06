using PatientManagement.Application.Dtos;
using PatientManagement.Application.Cares.Commands;
using PatientManagement.Domain.Entities;

namespace PatientManagement.Application.Mappers.Interfaces;

public interface ICareMapper
{
    CareDto ToDto(Care care);
    IEnumerable<CareDto> ToDtoIEnumerable(IEnumerable<Care> cares);
    Care ToEntity(CreateCareCommand command);
    Care ToEntity(UpdateCareCommand command);
}