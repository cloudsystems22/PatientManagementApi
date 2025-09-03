using Microsoft.EntityFrameworkCore;
using PatientManagement.Domain.Entities;
using PatientManagement.Domain.Repositories;
using PatientManagement.Infrastructure.Data;

namespace PatientManagement.Infrastructure.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly MSSQLDbContext _context;

    public PatientRepository(MSSQLDbContext context)
        => _context = context;


    public async Task<Patient?> GetByIdAsync(int id) =>
        await _context.Pacientes.FindAsync(id);

    public async Task<IEnumerable<Patient>> GetAllAsync() =>
        await _context.Pacientes.AsNoTracking().ToListAsync();

    public async Task AddAsync(Patient paciente)
    {
        await _context.Pacientes.AddAsync(paciente);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Patient paciente)
    {
        _context.Pacientes.Update(paciente);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var paciente = await _context.Pacientes.FindAsync(id);
        if (paciente is null) return;
        _context.Pacientes.Remove(paciente);
        await _context.SaveChangesAsync();
    }
}
