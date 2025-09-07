using Microsoft.EntityFrameworkCore;
using PatientManagement.Domain.Entities;

namespace PatientManagement.Infrastructure.Data;

public class MSSQLDbContext : DbContext
{
    public MSSQLDbContext(DbContextOptions<MSSQLDbContext> options) : base(options) { }

    public DbSet<Patient> Patient => Set<Patient>();
    public DbSet<Care> Care => Set<Care>();
    public DbSet<Triage> Triage => Set<Triage>();
    public DbSet<Speciality> Speciality => Set<Speciality>();

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