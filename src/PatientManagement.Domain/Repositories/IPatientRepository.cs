using PatientManagement.Domain.Entities;

namespace PatientManagement.Domain.Repositories;

public interface IPatientRepository
{
    Task<Patient?> GetByIdAsync(int id);
    Task<IEnumerable<Patient>> GetAllAsync();
    Task AddAsync(Patient paciente);
    Task UpdateAsync(Patient paciente);
    Task DeleteAsync(int id);
}
