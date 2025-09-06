using Microsoft.Extensions.Logging;
using PatientManagement.Domain.Entities;
using PatientManagement.Domain.Interfaces.Repositories.Triages;
using PatientManagement.Infrastructure.Data;

namespace PatientManagement.Infrastructure.Repositories;

public class TriageRepository : BaseRepository<Triage>, ITriageRepository
{
    private readonly MSSQLDbContext _context;
    private readonly ILogger<TriageRepository> _logger;

    public TriageRepository(MSSQLDbContext context, ILogger<TriageRepository> logger)
        : base(context, logger)
    {
        _context = context;
        _logger = logger;
    }
}