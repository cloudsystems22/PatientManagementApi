using Microsoft.EntityFrameworkCore;
using PatientManagement.Domain.Entities;

namespace PatientManagement.Infrastructure.Data;

public class MSSQLDbContext : DbContext
{
    public MSSQLDbContext(DbContextOptions<MSSQLDbContext> options) : base(options) { }

    public DbSet<Patient> Pacientes => Set<Patient>();
    public DbSet<Care> Atendimentos => Set<Care>();
    public DbSet<Triage> Triagens => Set<Triage>();
    public DbSet<Specialty> Especialidades => Set<Specialty>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Care>()
            .HasOne(a => a.Patient)
            .WithMany(p => p.Cares)
            .HasForeignKey(a => a.PatientId);

        modelBuilder.Entity<Triage>()
            .HasOne(t => t.Care)
            .WithOne(a => a.Triage)
            .HasForeignKey<Triage>(t => t.CareId);

        modelBuilder.Entity<Triage>()
            .HasOne(t => t.Specialty)
            .WithMany(e => e.Triagens)
            .HasForeignKey(t => t.SpecialtyId);
    }
}