using Microsoft.Extensions.Logging;
using PatientManagement.Domain.Entities;
using PatientManagement.Domain.Interfaces.Repositories.Patients;
using PatientManagement.Infrastructure.Data;

namespace PatientManagement.Infrastructure.Repositories;

public class PatientRepository : BaseRepository<Patient>, IPatientRepository 
{
    private readonly MSSQLDbContext _context;
    private readonly ILogger<PatientRepository> _logger;

    public PatientRepository(MSSQLDbContext context, ILogger<PatientRepository> logger)
    : base(context, logger)
    {
        _context = context;
        _logger = logger;
    }
    
}
