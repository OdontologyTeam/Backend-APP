using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DentistAPI.Model
{
    public partial class dentistdbContext : DbContext
    {
        public dentistdbContext()
        {
        }

        public dentistdbContext(DbContextOptions<dentistdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Antecedentemedico> Antecedentemedico { get; set; }
        public virtual DbSet<Antecedenteodontologico> Antecedenteodontologico { get; set; }
        public virtual DbSet<Antecendentesodontologicos> Antecendentesodontologicos { get; set; }
        public virtual DbSet<Antecentesmedicos> Antecentesmedicos { get; set; }
        public virtual DbSet<Consentimiento> Consentimiento { get; set; }
        public virtual DbSet<Diente> Diente { get; set; }
        public virtual DbSet<Historia> Historia { get; set; }
        public virtual DbSet<Lugar> Lugar { get; set; }
        public virtual DbSet<Ocupacion> Ocupacion { get; set; }
        public virtual DbSet<Odontograma> Odontograma { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }
        public virtual DbSet<Procedimiento> Procedimiento { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=sajago99;database=dentistdb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Antecedentemedico>(entity =>
            {
                entity.ToTable("antecedentemedico", "dentistdb");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Antecedenteodontologico>(entity =>
            {
                entity.ToTable("antecedenteodontologico", "dentistdb");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Antecendentesodontologicos>(entity =>
            {
                entity.HasKey(e => new { e.HistoriaPacienteCedula, e.AntecedenteOdontologicoId });

                entity.ToTable("antecendentesodontologicos", "dentistdb");

                entity.HasIndex(e => e.AntecedenteOdontologicoId)
                    .HasName("fk_AntecendentesOdontologicos_Antecedente Odontologico1_idx");

                entity.HasIndex(e => e.HistoriaPacienteCedula)
                    .HasName("fk_AntecendentesOdontologicos_Historia1_idx");

                entity.Property(e => e.HistoriaPacienteCedula)
                    .HasColumnName("Historia_Paciente_Cedula")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AntecedenteOdontologicoId)
                    .HasColumnName("AntecedenteOdontologico_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Observaciones)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.AntecedenteOdontologico)
                    .WithMany(p => p.Antecendentesodontologicos)
                    .HasForeignKey(d => d.AntecedenteOdontologicoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AntecendentesOdontologicos_Antecedente Odontologico1");

                entity.HasOne(d => d.HistoriaPacienteCedulaNavigation)
                    .WithMany(p => p.Antecendentesodontologicos)
                    .HasForeignKey(d => d.HistoriaPacienteCedula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AntecendentesOdontologicos_Historia1");
            });

            modelBuilder.Entity<Antecentesmedicos>(entity =>
            {
                entity.HasKey(e => new { e.HistoriaPacienteCedula, e.AntecedenteMedicoId });

                entity.ToTable("antecentesmedicos", "dentistdb");

                entity.HasIndex(e => e.AntecedenteMedicoId)
                    .HasName("fk_AntecentesMedicos_Antecedente Medico1_idx");

                entity.HasIndex(e => e.HistoriaPacienteCedula)
                    .HasName("fk_AntecentesMedicos_Historia1_idx");

                entity.Property(e => e.HistoriaPacienteCedula)
                    .HasColumnName("Historia_Paciente_Cedula")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AntecedenteMedicoId)
                    .HasColumnName("AntecedenteMedico_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Observaciones)
                    .IsRequired()
                    .HasColumnType("mediumtext");

                entity.HasOne(d => d.AntecedenteMedico)
                    .WithMany(p => p.Antecentesmedicos)
                    .HasForeignKey(d => d.AntecedenteMedicoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AntecentesMedicos_Antecedente Medico1");

                entity.HasOne(d => d.HistoriaPacienteCedulaNavigation)
                    .WithMany(p => p.Antecentesmedicos)
                    .HasForeignKey(d => d.HistoriaPacienteCedula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AntecentesMedicos_Historia1");
            });

            modelBuilder.Entity<Consentimiento>(entity =>
            {
                entity.HasKey(e => e.ProcedimientoId);

                entity.ToTable("consentimiento", "dentistdb");

                entity.HasIndex(e => e.ProcedimientoId)
                    .HasName("fk_Consentimiento_Procedimiento1_idx");

                entity.Property(e => e.ProcedimientoId)
                    .HasColumnName("Procedimiento_Id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.HuellaPaciente)
                    .HasColumnName("Huella_Paciente")
                    .HasColumnType("longblob");

                entity.HasOne(d => d.Procedimiento)
                    .WithOne(p => p.Consentimiento)
                    .HasForeignKey<Consentimiento>(d => d.ProcedimientoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Consentimiento_Procedimiento1");
            });

            modelBuilder.Entity<Diente>(entity =>
            {
                entity.HasKey(e => e.NumeroDiente);

                entity.ToTable("diente", "dentistdb");

                entity.Property(e => e.NumeroDiente)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Historia>(entity =>
            {
                entity.HasKey(e => e.PacienteCedula);

                entity.ToTable("historia", "dentistdb");

                entity.HasIndex(e => e.PacienteCedula)
                    .HasName("fk_Historia_Paciente1_idx");

                entity.Property(e => e.PacienteCedula)
                    .HasColumnName("Paciente_Cedula")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.MotivoConsulta)
                    .IsRequired()
                    .HasColumnName("Motivo_Consulta")
                    .HasColumnType("mediumtext");

                entity.HasOne(d => d.PacienteCedulaNavigation)
                    .WithOne(p => p.Historia)
                    .HasForeignKey<Historia>(d => d.PacienteCedula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Historia_Paciente1");
            });

            modelBuilder.Entity<Lugar>(entity =>
            {
                entity.ToTable("lugar", "dentistdb");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Lugar1)
                    .IsRequired()
                    .HasColumnName("Lugar")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ocupacion>(entity =>
            {
                entity.ToTable("ocupacion", "dentistdb");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Ocupacion1)
                    .IsRequired()
                    .HasColumnName("Ocupacion")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Odontograma>(entity =>
            {
                entity.HasKey(e => new { e.HistoriaPacienteCedula, e.DienteNumeroDiente });

                entity.ToTable("odontograma", "dentistdb");

                entity.HasIndex(e => e.DienteNumeroDiente)
                    .HasName("fk_Odontograma_Diente1_idx");

                entity.Property(e => e.HistoriaPacienteCedula)
                    .HasColumnName("Historia_Paciente_Cedula")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DienteNumeroDiente)
                    .HasColumnName("Diente_NumeroDiente")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Observacion).HasColumnType("mediumtext");

                entity.HasOne(d => d.DienteNumeroDienteNavigation)
                    .WithMany(p => p.Odontograma)
                    .HasForeignKey(d => d.DienteNumeroDiente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Odontograma_Diente1");

                entity.HasOne(d => d.HistoriaPacienteCedulaNavigation)
                    .WithMany(p => p.Odontograma)
                    .HasForeignKey(d => d.HistoriaPacienteCedula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Odontograma_Historia1");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.Cedula);

                entity.ToTable("paciente", "dentistdb");

                entity.HasIndex(e => e.LugarCedula)
                    .HasName("fk_Paciente_Lugar1_idx");

                entity.HasIndex(e => e.LugarNacimiento)
                    .HasName("fk_Paciente_Lugar_idx");

                entity.HasIndex(e => e.Ocupacion)
                    .HasName("fk_Paciente_Ocupacion1_idx");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnName("Fecha_Nacimiento");

                entity.Property(e => e.LugarCedula)
                    .HasColumnName("Lugar_Cedula")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LugarNacimiento)
                    .HasColumnName("Lugar_Nacimiento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Ocupacion).HasColumnType("int(11)");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.HasOne(d => d.LugarCedulaNavigation)
                    .WithMany(p => p.PacienteLugarCedulaNavigation)
                    .HasForeignKey(d => d.LugarCedula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Paciente_Lugar1");

                entity.HasOne(d => d.LugarNacimientoNavigation)
                    .WithMany(p => p.PacienteLugarNacimientoNavigation)
                    .HasForeignKey(d => d.LugarNacimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Paciente_Lugar");

                entity.HasOne(d => d.OcupacionNavigation)
                    .WithMany(p => p.Paciente)
                    .HasForeignKey(d => d.Ocupacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Paciente_Ocupacion1");
            });

            modelBuilder.Entity<Procedimiento>(entity =>
            {
                entity.ToTable("procedimiento", "dentistdb");

                entity.HasIndex(e => e.DienteNumeroDiente)
                    .HasName("fk_Procedimiento_Diente1_idx");

                entity.HasIndex(e => e.HistoriaPacienteCedula)
                    .HasName("fk_Procedimiento_Historia1_idx");

                entity.HasIndex(e => e.RealizadoPorUsuarioCedula)
                    .HasName("fk_Procedimiento_Usuario1_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Accesorios)
                    .IsRequired()
                    .HasColumnType("mediumtext");

                entity.Property(e => e.AperturaCameral)
                    .IsRequired()
                    .HasColumnName("Apertura_Cameral")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.Carpul)
                    .IsRequired()
                    .HasColumnName("CARPUL")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.CementoEndodontico)
                    .IsRequired()
                    .HasColumnName("Cemento_Endodontico")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.ComplicacionesRecomendaciones)
                    .IsRequired()
                    .HasColumnName("Complicaciones_Recomendaciones")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.ConoPrincipal)
                    .IsRequired()
                    .HasColumnName("Cono_Principal")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnType("mediumtext");

                entity.Property(e => e.DiagnosticoFinal)
                    .IsRequired()
                    .HasColumnName("Diagnostico_Final")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.DiagnosticoInicial)
                    .IsRequired()
                    .HasColumnName("Diagnostico_Inicial")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.DienteNumeroDiente)
                    .IsRequired()
                    .HasColumnName("Diente_NumeroDiente")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.HistoriaPacienteCedula)
                    .IsRequired()
                    .HasColumnName("Historia_Paciente_Cedula")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HoraEntrada).HasColumnName("Hora_Entrada");

                entity.Property(e => e.HoraSalida).HasColumnName("Hora_Salida");

                entity.Property(e => e.Irrigacion)
                    .IsRequired()
                    .HasColumnType("mediumtext");

                entity.Property(e => e.LongitudTrabajo)
                    .IsRequired()
                    .HasColumnName("Longitud_Trabajo")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.ObturacionBase)
                    .IsRequired()
                    .HasColumnName("Obturacion_Base")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.ObturacionTemporal)
                    .IsRequired()
                    .HasColumnName("Obturacion_Temporal")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.Pronostico)
                    .IsRequired()
                    .HasColumnType("mediumtext");

                entity.Property(e => e.PruebasSensibilidad)
                    .IsRequired()
                    .HasColumnName("Pruebas_Sensibilidad")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.RealizadoPorUsuarioCedula)
                    .IsRequired()
                    .HasColumnName("RealizadoPor_Usuario_Cedula")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RxInicial)
                    .IsRequired()
                    .HasColumnName("RX_Inicial")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.SecadoConducto)
                    .IsRequired()
                    .HasColumnName("Secado_Conducto")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.SistemaLimas)
                    .IsRequired()
                    .HasColumnName("Sistema_Limas")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.TecnicaAnestesica)
                    .IsRequired()
                    .HasColumnName("Tecnica_Anestesica")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.TecnicaObturacion)
                    .IsRequired()
                    .HasColumnName("Tecnica_Obturacion")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.TipoAislamiento)
                    .IsRequired()
                    .HasColumnName("Tipo_Aislamiento")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.TipoAnestesia)
                    .IsRequired()
                    .HasColumnName("Tipo_Anestesia")
                    .HasColumnType("mediumtext");

                entity.HasOne(d => d.DienteNumeroDienteNavigation)
                    .WithMany(p => p.Procedimiento)
                    .HasForeignKey(d => d.DienteNumeroDiente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Procedimiento_Diente1");

                entity.HasOne(d => d.HistoriaPacienteCedulaNavigation)
                    .WithMany(p => p.Procedimiento)
                    .HasForeignKey(d => d.HistoriaPacienteCedula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Procedimiento_Historia1");

                entity.HasOne(d => d.RealizadoPorUsuarioCedulaNavigation)
                    .WithMany(p => p.Procedimiento)
                    .HasForeignKey(d => d.RealizadoPorUsuarioCedula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Procedimiento_Usuario1");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Cedula);

                entity.ToTable("usuario", "dentistdb");

                entity.HasIndex(e => e.Email)
                    .HasName("Email_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Cedula)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Huella).HasColumnType("longblob");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });
        }
    }
}
