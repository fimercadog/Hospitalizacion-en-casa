using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HospiEnCasa.Models
{
    public partial class HospiEnCasaDataContext : DbContext
    {
        public HospiEnCasaDataContext()
        {
        }

        public HospiEnCasaDataContext(DbContextOptions<HospiEnCasaDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Enfermera> Enfermeras { get; set; } = null!;
        public virtual DbSet<FamiliaresDesignado> FamiliaresDesignados { get; set; } = null!;
        public virtual DbSet<Historia> Historias { get; set; } = null!;
        public virtual DbSet<Medico> Medicos { get; set; } = null!;
        public virtual DbSet<Paciente> Pacientes { get; set; } = null!;
        public virtual DbSet<SignosVitale> SignosVitales { get; set; } = null!;
        public virtual DbSet<SugerenciasCuidado> SugerenciasCuidados { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=HospiEnCasa.Data;integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enfermera>(entity =>
            {
                entity.Property(e => e.HorasLaboradas).HasColumnName("horas_laboradas");
            });

            modelBuilder.Entity<SugerenciasCuidado>(entity =>
            {
                entity.ToTable("SugerenciasCuidado");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
