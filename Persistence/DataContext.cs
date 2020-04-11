using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Persistence
{
    public class DataContext: IdentityDbContext<User>
    {
        public DbSet<Value> Values { get; set; }
        public DbSet<Records> Records { get; set; }
        public DbSet<Pacient> Pacients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Diseases> Diseases { get; set; }
        public DbSet<Medications> Medications { get; set; }
        public DbSet<Vaccinations> Vaccinations { get; set; }
        public DbSet<Allergies> Allergies { get; set; }
        public DbSet<HistoryDiseases> HistoryDiseases { get; set; }
        public DbSet<HistoryAllergies> HistoryAllergies { get; set; }
        public DbSet<HistoryMedications> HistoryMedications { get; set; }
        public DbSet<HistoryVaccinations> HistoryVaccinations { get; set; }

        public DataContext() : base()
        {

        }
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Pacient>()
                .Property(p => p.DoctorId)
                .IsRequired(false);

            builder.Entity<HistoryDiseases>()
                .HasKey(pd => new { pd.DiseasesId, pd.PacientId, pd.Id });
            builder.Entity<HistoryDiseases>()
                .HasOne(pd => pd.Pacient)
                .WithMany(p => p.HistoryDiseases)
                .HasForeignKey(pd => pd.PacientId);
            builder.Entity<HistoryDiseases>()
                .HasOne(pd => pd.Diseases)
                .WithMany(d => d.HistoryDiseases)
                .HasForeignKey(pd => pd.DiseasesId);

            builder.Entity<HistoryMedications>()
                .HasKey(pm => new { pm.MedicationsId, pm.PacientId });
            builder.Entity<HistoryMedications>()
                .HasOne(pm => pm.Pacient)
                .WithMany(p => p.HistoryMedications)
                .HasForeignKey(pm => pm.PacientId);
            builder.Entity<HistoryMedications>()
                .HasOne(pm => pm.Medications)
                .WithMany(d => d.HistoryMedications)
                .HasForeignKey(pm => pm.MedicationsId);

            builder.Entity<HistoryAllergies>()
                .HasKey(pa => new { pa.AllergiesId, pa.PacientId });
            builder.Entity<HistoryAllergies>()
                .HasOne(pa => pa.Pacient)
                .WithMany(p => p.HistoryAllergies)
                .HasForeignKey(pa => pa.PacientId);
            builder.Entity<HistoryAllergies>()
                .HasOne(pa => pa.Allergies)
                .WithMany(d => d.HistoryAllergies)
                .HasForeignKey(pa => pa.AllergiesId);

            builder.Entity<HistoryVaccinations>()
                .HasKey(pv => new { pv.VaccinationsId, pv.PacientId });
            builder.Entity<HistoryVaccinations>()
                .HasOne(pv => pv.Pacient)
                .WithMany(p => p.HistoryVaccinations)
                .HasForeignKey(pv => pv.PacientId);
            builder.Entity<HistoryVaccinations>()
                .HasOne(pv => pv.Vaccinations)
                .WithMany(d => d.HistoryVaccinations)
                .HasForeignKey(pv => pv.VaccinationsId);

            //builder.Entity<Value>().HasData(
            //    new Value { Id = new Guid(), Name = "John", Surname = "Smith" }
            //    );
        }
    }
}
