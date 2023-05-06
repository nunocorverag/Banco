using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Banco.Server.Models;

public partial class BancoContext : DbContext
{
    public BancoContext()
    {
    }

    public BancoContext(DbContextOptions<BancoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrador> Administradors { get; set; }

    public virtual DbSet<Boleto> Boletos { get; set; }

    public virtual DbSet<Cuentum> Cuenta { get; set; }

    public virtual DbSet<CurpEstatus> CurpEstatuses { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Gerente> Gerentes { get; set; }

    public virtual DbSet<InfoPersona> InfoPersonas { get; set; }

    public virtual DbSet<LoginAttempt> LoginAttempts { get; set; }

    public virtual DbSet<Nomina> Nominas { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<Solicitud> Solicituds { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=GUSTAVOACER\\SQLEXPRESS;Database=banco;Integrated Security=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>(entity =>
        {
            entity.HasKey(e => e.IdAdministrador).HasName("PK__administ__2D89616F90857F17");

            entity.ToTable("administrador");

            entity.Property(e => e.IdAdministrador).HasColumnName("ID_Administrador");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Administradors)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("administrador_ibfk_1");
        });

        modelBuilder.Entity<Boleto>(entity =>
        {
            entity.HasKey(e => e.IdBoleto).HasName("PK__boleto__75FF3CC0B250BE36");

            entity.ToTable("boleto");

            entity.Property(e => e.IdBoleto).HasColumnName("ID_Boleto");
            entity.Property(e => e.FolioPrestamo).HasColumnName("Folio_Prestamo");
            entity.Property(e => e.PrimeraParticipacion)
                .HasColumnType("date")
                .HasColumnName("Primera_Participacion");

            entity.HasOne(d => d.FolioPrestamoNavigation).WithMany(p => p.BoletosNavigation)
                .HasForeignKey(d => d.FolioPrestamo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("boleto_ibfk_1");
        });

        modelBuilder.Entity<Cuentum>(entity =>
        {
            entity.HasKey(e => e.NumeroCuenta).HasName("PK__cuenta__D36A7DF947444CDA");

            entity.ToTable("cuenta");

            entity.Property(e => e.NumeroCuenta)
                .ValueGeneratedNever()
                .HasColumnName("Numero_Cuenta");
            entity.Property(e => e.Curp)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("CURP");
            entity.Property(e => e.IdPersona).HasColumnName("ID_Persona");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.Saldo).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.CurpNavigation).WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.Curp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cuenta_ibfk_3");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cuenta_ibfk_2");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cuenta_ibfk_1");
        });

        modelBuilder.Entity<CurpEstatus>(entity =>
        {
            entity.HasKey(e => e.Curp).HasName("PK__curp_est__F46C4CBEE58DC6E2");

            entity.ToTable("curp_estatus");

            entity.Property(e => e.Curp)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("CURP");
            entity.Property(e => e.Estatus)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.IdPersona).HasColumnName("ID_Persona");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.CurpEstatuses)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("curp_estatus_ibfk_1");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__empleado__B7872C90755E40ED");

            entity.ToTable("empleado");

            entity.Property(e => e.IdEmpleado).HasColumnName("ID_Empleado");
            entity.Property(e => e.IdPersona).HasColumnName("ID_Persona");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.PrestamosAprobados).HasColumnName("Prestamos_Aprobados");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("empleado_ibfk_2");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("empleado_ibfk_1");

            entity.HasOne(d => d.NominaNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.Nomina)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("empleado_ibfk_3");
        });

        modelBuilder.Entity<Gerente>(entity =>
        {
            entity.HasKey(e => e.IdGerente).HasName("PK__gerente__D91F9588C8614D00");

            entity.ToTable("gerente");

            entity.Property(e => e.IdGerente).HasColumnName("ID_Gerente");
            entity.Property(e => e.DiasVacaciones).HasColumnName("Dias_Vacaciones");
            entity.Property(e => e.IdEmpleado).HasColumnName("ID_Empleado");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Gerentes)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__gerente__ID_Empl__29B719D8");
        });

        modelBuilder.Entity<InfoPersona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PK__info_per__E9916EC1E74F56D3");

            entity.ToTable("info_persona");

            entity.Property(e => e.IdPersona).HasColumnName("ID_Persona");
            entity.Property(e => e.ApeM)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Ape_M");
            entity.Property(e => e.ApeP)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Ape_P");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("Fecha_Nacimiento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LoginAttempt>(entity =>
        {
            entity.HasKey(e => e.IpAddress).HasName("PK__login_at__5376BCC53CAEB95B");

            entity.ToTable("login_attempts");

            entity.Property(e => e.IpAddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ip_address");
            entity.Property(e => e.FailedAttempts).HasColumnName("failed_attempts");
            entity.Property(e => e.LockoutTime)
                .HasColumnType("datetime")
                .HasColumnName("lockout_time");
        });

        modelBuilder.Entity<Nomina>(entity =>
        {
            entity.HasKey(e => e.Nomina1).HasName("PK__nomina__765BE2D8F03322C4");

            entity.ToTable("nomina");

            entity.Property(e => e.Nomina1).HasColumnName("Nomina");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("PK__pago__AE88B429EACDBB86");

            entity.ToTable("pago");

            entity.Property(e => e.IdPago).HasColumnName("ID_Pago");
            entity.Property(e => e.CantidadPago)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Cantidad_Pago");
            entity.Property(e => e.FechaPago)
                .HasColumnType("date")
                .HasColumnName("Fecha_Pago");
            entity.Property(e => e.IdPrestamoPagado).HasColumnName("ID_Prestamo_Pagado");
            entity.Property(e => e.NumeroCuentaPago).HasColumnName("Numero_Cuenta_Pago");

            entity.HasOne(d => d.IdPrestamoPagadoNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdPrestamoPagado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__pago__ID_Prestam__202DAF9E");

            entity.HasOne(d => d.NumeroCuentaPagoNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.NumeroCuentaPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__pago__Numero_Cue__2121D3D7");
        });

        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.HasKey(e => e.Folio).HasName("PK__prestamo__BAB84EF671EC1A15");

            entity.ToTable("prestamo");

            entity.Property(e => e.CategoriaPrestamo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Categoria_Prestamo");
            entity.Property(e => e.Estado)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FechaAprobacion)
                .HasColumnType("date")
                .HasColumnName("Fecha_Aprobacion");
            entity.Property(e => e.FechaUltimoPago)
                .HasColumnType("date")
                .HasColumnName("Fecha_Ultimo_Pago");
            entity.Property(e => e.IdEmpleado).HasColumnName("ID_Empleado");
            entity.Property(e => e.IdSolicitud).HasColumnName("ID_Solicitud");
            entity.Property(e => e.NumeroCuenta).HasColumnName("Numero_Cuenta");
            entity.Property(e => e.PagoMensual)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Pago_Mensual");
            entity.Property(e => e.PorcentajePagado)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Porcentaje_Pagado");
            entity.Property(e => e.VecesPagado).HasColumnName("Veces_Pagado");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("prestamo_ibfk_2");

            entity.HasOne(d => d.IdSolicitudNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.IdSolicitud)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("prestamo_ibfk_3");

            entity.HasOne(d => d.NumeroCuentaNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.NumeroCuenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("prestamo_ibfk_1");
        });

        modelBuilder.Entity<Solicitud>(entity =>
        {
            entity.HasKey(e => e.IdSolicitud).HasName("PK__solicitu__ED71123AA7107F50");

            entity.ToTable("solicitud");

            entity.Property(e => e.IdSolicitud).HasColumnName("ID_Solicitud");
            entity.Property(e => e.FechaSolicitud)
                .HasColumnType("date")
                .HasColumnName("Fecha_Solicitud");
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.NumeroCuenta).HasColumnName("Numero_Cuenta");
            entity.Property(e => e.Situacion)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.NumeroCuentaNavigation).WithMany(p => p.Solicituds)
                .HasForeignKey(d => d.NumeroCuenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("solicitud_ibfk_1");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__usuario__DE4431C5B28DE36E");

            entity.ToTable("usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
