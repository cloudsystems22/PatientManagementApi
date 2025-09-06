using Microsoft.Extensions.Logging;
using PatientManagement.Domain.Entities;
using PatientManagement.Domain.Interfaces.Repositories.Specialities;
using PatientManagement.Infrastructure.Data;

namespace PatientManagement.Infrastructure.Repositories;

public class SpecialityRepository : BaseRepository<Speciality>, ISpecialityRepository
{
    private readonly MSSQLDbContext _context;
    private readonly ILogger<SpecialityRepository> _logger;

    public SpecialityRepository(MSSQLDbContext context, ILogger<SpecialityRepository> logger)
        : base(context, logger)
    {
        _context = context;
        _logger = logger;
    }
}