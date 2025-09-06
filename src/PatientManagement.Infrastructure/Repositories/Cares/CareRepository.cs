using Microsoft.Extensions.Logging;
using PatientManagement.Domain.Entities;
using PatientManagement.Domain.Interfaces.Repositories.Cares;
using PatientManagement.Infrastructure.Data;

namespace PatientManagement.Infrastructure.Repositories;

public class CareRepository : BaseRepository<Care>, ICareRepository
{
    private readonly MSSQLDbContext _context;
    private readonly ILogger<CareRepository> _logger;

    public CareRepository(MSSQLDbContext context, ILogger<CareRepository> logger)
        : base(context, logger)
    {
        _context = context;
        _logger = logger;
    }
}