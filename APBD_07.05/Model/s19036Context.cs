using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APBD_07._05.Model
{
    public partial class s19036Context : DbContext
    {
        public s19036Context()
        {
        }

        public s19036Context(DbContextOptions<s19036Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animal { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Enrollment> Enrollment { get; set; }
        public virtual DbSet<Medicament> Medicament { get; set; }
        public virtual DbSet<Owner> Owner { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Prescription> Prescription { get; set; }
        public virtual DbSet<PrescriptionMedicament> PrescriptionMedicament { get; set; }
        public virtual DbSet<Procedure> Procedure { get; set; }
        public virtual DbSet<ProcedureAnimal> ProcedureAnimal { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Studies> Studies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>(entity =>
            {
                entity.HasKey(x => x.IdAnimal)
                    .HasName("Animal_pk");

                entity.Property(e => e.AdmissionDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdOwnerNavigation)
                    .WithMany(p => p.Animal)
                    .HasForeignKey(x => x.IdOwner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Animal_Owner");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(x => x.IdDoctor)
                    .HasName("Doctor_pk");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasKey(x => x.IdEnrollment)
                    .HasName("Enrollment_pk");

                entity.Property(e => e.IdEnrollment).ValueGeneratedNever();

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.IdStudyNavigation)
                    .WithMany(p => p.Enrollment)
                    .HasForeignKey(x => x.IdStudy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Enrollment_Studies");
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(x => x.IdMedicament)
                    .HasName("Medicament_pk");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.HasKey(x => x.IdOwner)
                    .HasName("Owner_pk");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(x => x.IdPatient)
                    .HasName("Patient_pk");

                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasKey(x => x.IdPrescription)
                    .HasName("Prescription_pk");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DueDate).HasColumnType("date");

                entity.HasOne(d => d.IdDoctorNavigation)
                    .WithMany(p => p.Prescription)
                    .HasForeignKey(x => x.IdDoctor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescription_Doctor");

                entity.HasOne(d => d.IdPatientNavigation)
                    .WithMany(p => p.Prescription)
                    .HasForeignKey(x => x.IdPatient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescription_Patient");
            });

            modelBuilder.Entity<PrescriptionMedicament>(entity =>
            {
                entity.HasKey(x => new { x.IdMedicament, x.IdPrescription })
                    .HasName("Prescription_Medicament_pk");

                entity.ToTable("Prescription_Medicament");

                entity.Property(e => e.Details)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdMedicamentNavigation)
                    .WithMany(p => p.PrescriptionMedicament)
                    .HasForeignKey(x => x.IdMedicament)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescription_Medicament_Medicament");

                entity.HasOne(d => d.IdPrescriptionNavigation)
                    .WithMany(p => p.PrescriptionMedicament)
                    .HasForeignKey(x => x.IdPrescription)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescription_Medicament_Prescription");
            });

            modelBuilder.Entity<Procedure>(entity =>
            {
                entity.HasKey(x => x.IdProcedure)
                    .HasName("Procedure_pk");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ProcedureAnimal>(entity =>
            {
                entity.HasKey(x => new { x.ProcedureIdProcedure, x.AnimalIdAnimal, x.Date })
                    .HasName("Procedure_Animal_pk");

                entity.ToTable("Procedure_Animal");

                entity.Property(e => e.ProcedureIdProcedure).HasColumnName("Procedure_IdProcedure");

                entity.Property(e => e.AnimalIdAnimal).HasColumnName("Animal_IdAnimal");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.AnimalIdAnimalNavigation)
                    .WithMany(p => p.ProcedureAnimal)
                    .HasForeignKey(x => x.AnimalIdAnimal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_3_Animal");

                entity.HasOne(d => d.ProcedureIdProcedureNavigation)
                    .WithMany(p => p.ProcedureAnimal)
                    .HasForeignKey(x => x.ProcedureIdProcedure)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_3_Procedure");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(x => x.IndexNumber)
                    .HasName("Student_pk");

                entity.Property(e => e.IndexNumber).HasMaxLength(100);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEnrollmentNavigation)
                    .WithMany(p => p.Student)
                    .HasForeignKey(x => x.IdEnrollment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Student_Enrollment");
            });

            modelBuilder.Entity<Studies>(entity =>
            {
                entity.HasKey(x => x.IdStudy)
                    .HasName("Studies_pk");

                entity.Property(e => e.IdStudy).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
