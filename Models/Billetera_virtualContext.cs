using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WepAppClip.Models
{
    public partial class Billetera_virtualContext : DbContext
    {
        public Billetera_virtualContext()
        {
        }

        public Billetera_virtualContext(DbContextOptions<Billetera_virtualContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Cuentum> Cuenta { get; set; }
        public virtual DbSet<DetalleFactura> DetalleFacturas { get; set; }
        public virtual DbSet<Direccion> Direccions { get; set; }
        public virtual DbSet<EntidadBancarium> EntidadBancaria { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<Inversion> Inversions { get; set; }
        public virtual DbSet<Localidad> Localidads { get; set; }
        public virtual DbSet<Operacion> Operacions { get; set; }
        public virtual DbSet<Pago> Pagos { get; set; }
        public virtual DbSet<Provincium> Provincia { get; set; }
        public virtual DbSet<Servicio> Servicios { get; set; }
        public virtual DbSet<TipoInversion> TipoInversions { get; set; }
        public virtual DbSet<TipoMonedum> TipoMoneda { get; set; }
        public virtual DbSet<TipoOperacion> TipoOperacions { get; set; }
        public virtual DbSet<TipoServicio> TipoServicios { get; set; }
        public virtual DbSet<Transferencium> Transferencia { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=MIRKO;Initial Catalog=billetera_virtual;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.ToTable("Cliente");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .HasColumnName("apellido");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FrontalDni)
                    .HasColumnType("image")
                    .HasColumnName("frontalDNI");

                entity.Property(e => e.IdDireccion).HasColumnName("idDireccion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.NroDni)
                    .HasMaxLength(10)
                    .HasColumnName("nroDNI")
                    .IsFixedLength(true);

                entity.Property(e => e.NroTelefono)
                    .HasMaxLength(50)
                    .HasColumnName("nroTelefono");

                entity.Property(e => e.Password)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.TraseraDni)
                    .HasColumnType("image")
                    .HasColumnName("traseraDNI");

                entity.HasOne(d => d.IdDireccionNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdDireccion)
                    .HasConstraintName("FK_Cliente_Direccion");
            });

            modelBuilder.Entity<Cuentum>(entity =>
            {
                entity.HasKey(e => e.IdCuenta);

                entity.Property(e => e.IdCuenta).HasColumnName("idCuenta");

                entity.Property(e => e.Cvu)
                    .HasMaxLength(50)
                    .HasColumnName("cvu");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaAlta)
                    .HasColumnType("date")
                    .HasColumnName("fechaAlta");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.IdEntidadBancaria).HasColumnName("idEntidadBancaria");

                entity.Property(e => e.IdTipoMoneda).HasColumnName("idTipoMoneda");

                entity.Property(e => e.Saldo)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("saldo");

                entity.Property(e => e.TopeDescubierto)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("topeDescubierto");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_Cuenta_Cliente");

                entity.HasOne(d => d.IdEntidadBancariaNavigation)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.IdEntidadBancaria)
                    .HasConstraintName("FK_Cuenta_Entidad_Bancaria");

                entity.HasOne(d => d.IdTipoMonedaNavigation)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.IdTipoMoneda)
                    .HasConstraintName("FK_Cuenta_Tipo_Moneda");
            });

            modelBuilder.Entity<DetalleFactura>(entity =>
            {
                entity.HasKey(e => e.IdDetalleFactura);

                entity.ToTable("DetalleFactura");

                entity.Property(e => e.IdDetalleFactura)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idDetalleFactura");

                entity.Property(e => e.IdFactura).HasColumnName("idFactura");

                entity.Property(e => e.IdServicio).HasColumnName("idServicio");

                entity.Property(e => e.SubTotal)
                    .HasMaxLength(10)
                    .HasColumnName("subTotal")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdDetalleFacturaNavigation)
                    .WithOne(p => p.DetalleFactura)
                    .HasForeignKey<DetalleFactura>(d => d.IdDetalleFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleFactura_Factura");

                entity.HasOne(d => d.IdServicioNavigation)
                    .WithMany(p => p.DetalleFacturas)
                    .HasForeignKey(d => d.IdServicio)
                    .HasConstraintName("FK_DetalleFactura_Servicio");
            });

            modelBuilder.Entity<Direccion>(entity =>
            {
                entity.HasKey(e => e.IdDireccion);

                entity.ToTable("Direccion");

                entity.Property(e => e.IdDireccion).HasColumnName("idDireccion");

                entity.Property(e => e.Calle)
                    .HasMaxLength(20)
                    .HasColumnName("calle")
                    .IsFixedLength(true);

                entity.Property(e => e.IdLocalidad).HasColumnName("idLocalidad");

                entity.Property(e => e.Numero)
                    .HasMaxLength(10)
                    .HasColumnName("numero")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdLocalidadNavigation)
                    .WithMany(p => p.Direccions)
                    .HasForeignKey(d => d.IdLocalidad)
                    .HasConstraintName("FK_Direccion_Localidad");
            });

            modelBuilder.Entity<EntidadBancarium>(entity =>
            {
                entity.HasKey(e => e.IdEntidadBancaria);

                entity.ToTable("Entidad_Bancaria");

                entity.Property(e => e.IdEntidadBancaria)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idEntidadBancaria");

                entity.Property(e => e.IdDireccion).HasColumnName("idDireccion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(10)
                    .HasColumnName("nombre")
                    .IsFixedLength(true);

                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(10)
                    .HasColumnName("razonSocial")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdEntidadBancariaNavigation)
                    .WithOne(p => p.EntidadBancarium)
                    .HasForeignKey<EntidadBancarium>(d => d.IdEntidadBancaria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Entidad_Bancaria_Direccion");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura);

                entity.ToTable("Factura");

                entity.Property(e => e.IdFactura).HasColumnName("idFactura");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaElaboracion)
                    .HasColumnType("date")
                    .HasColumnName("fechaElaboracion");

                entity.Property(e => e.FechaVencimiento)
                    .HasMaxLength(10)
                    .HasColumnName("fechaVencimiento")
                    .IsFixedLength(true);

                entity.Property(e => e.Total)
                    .HasColumnType("numeric(8, 2)")
                    .HasColumnName("total");
            });

            modelBuilder.Entity<Inversion>(entity =>
            {
                entity.HasKey(e => e.IdInversion);

                entity.ToTable("Inversion");

                entity.Property(e => e.IdInversion)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idInversion");

                entity.Property(e => e.CantidadDias).HasColumnName("cantidadDias");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("fechaInicio");

                entity.Property(e => e.IdCuenta).HasColumnName("idCuenta");

                entity.Property(e => e.IdTipoInversion).HasColumnName("idTipoInversion");

                entity.Property(e => e.MontoInicial)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("montoInicial");

                entity.HasOne(d => d.IdCuentaNavigation)
                    .WithMany(p => p.Inversions)
                    .HasForeignKey(d => d.IdCuenta)
                    .HasConstraintName("FK_Inversion_Cuenta");

                entity.HasOne(d => d.IdInversionNavigation)
                    .WithOne(p => p.Inversion)
                    .HasForeignKey<Inversion>(d => d.IdInversion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inversion_Tipo_Inversion");
            });

            modelBuilder.Entity<Localidad>(entity =>
            {
                entity.HasKey(e => e.IdLocalidad);

                entity.ToTable("Localidad");

                entity.Property(e => e.IdLocalidad).HasColumnName("idLocalidad");

                entity.Property(e => e.CodigoPostal)
                    .HasMaxLength(10)
                    .HasColumnName("codigoPostal")
                    .IsFixedLength(true);

                entity.Property(e => e.IdProvincia).HasColumnName("idProvincia");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .HasColumnName("nombre")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Localidads)
                    .HasForeignKey(d => d.IdProvincia)
                    .HasConstraintName("FK_Localidad_Provincia");
            });

            modelBuilder.Entity<Operacion>(entity =>
            {
                entity.HasKey(e => e.IdOperacion);

                entity.ToTable("Operacion");

                entity.Property(e => e.IdOperacion)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idOperacion");

                entity.Property(e => e.Estado)
                    .HasMaxLength(10)
                    .HasColumnName("estado")
                    .IsFixedLength(true);

                entity.Property(e => e.FechaOperacion)
                    .HasColumnType("date")
                    .HasColumnName("fechaOperacion");

                entity.Property(e => e.HoraOperacion)
                    .HasMaxLength(10)
                    .HasColumnName("horaOperacion")
                    .IsFixedLength(true);

                entity.Property(e => e.IdCuenta).HasColumnName("idCuenta");

                entity.Property(e => e.IdTipoOperacion).HasColumnName("idTipoOperacion");

                entity.Property(e => e.Monto)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("monto");

                entity.Property(e => e.NroOperacion)
                    .HasMaxLength(10)
                    .HasColumnName("nroOperacion")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdCuentaNavigation)
                    .WithMany(p => p.Operacions)
                    .HasForeignKey(d => d.IdCuenta)
                    .HasConstraintName("FK_Operacion_Cuenta");

                entity.HasOne(d => d.IdOperacionNavigation)
                    .WithOne(p => p.Operacion)
                    .HasForeignKey<Operacion>(d => d.IdOperacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Operacion_Tipo_Operacion");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.HasKey(e => e.IdPago);

                entity.ToTable("Pago");

                entity.Property(e => e.IdPago).HasColumnName("idPago");

                entity.Property(e => e.CantCuotas).HasColumnName("cantCuotas");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdCuenta).HasColumnName("idCuenta");

                entity.Property(e => e.IdFactura).HasColumnName("idFactura");

                entity.Property(e => e.Total)
                    .HasColumnType("numeric(8, 2)")
                    .HasColumnName("total");

                entity.HasOne(d => d.IdCuentaNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.IdCuenta)
                    .HasConstraintName("FK_Pago_Cuenta");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.IdFactura)
                    .HasConstraintName("FK_Pago_Factura");
            });

            modelBuilder.Entity<Provincium>(entity =>
            {
                entity.HasKey(e => e.IdProvincia)
                    .HasName("PK_Estado");

                entity.Property(e => e.IdProvincia).HasColumnName("idProvincia");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(10)
                    .HasColumnName("descripcion")
                    .IsFixedLength(true);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .HasColumnName("nombre")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.HasKey(e => e.IdServicio);

                entity.ToTable("Servicio");

                entity.Property(e => e.IdServicio)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idServicio");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(10)
                    .HasColumnName("descripcion")
                    .IsFixedLength(true);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.IdTipoServicio).HasColumnName("idTipoServicio");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(10)
                    .HasColumnName("nombre")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdServicioNavigation)
                    .WithOne(p => p.Servicio)
                    .HasForeignKey<Servicio>(d => d.IdServicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Servicio_Tipo_Servicio");
            });

            modelBuilder.Entity<TipoInversion>(entity =>
            {
                entity.HasKey(e => e.IdTipoInversion);

                entity.ToTable("Tipo_Inversion");

                entity.Property(e => e.IdTipoInversion).HasColumnName("idTipoInversion");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(10)
                    .HasColumnName("descripcion")
                    .IsFixedLength(true);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(10)
                    .HasColumnName("nombre")
                    .IsFixedLength(true);

                entity.Property(e => e.Tasa)
                    .HasColumnType("numeric(2, 2)")
                    .HasColumnName("tasa");
            });

            modelBuilder.Entity<TipoMonedum>(entity =>
            {
                entity.HasKey(e => e.IdTipoMoneda);

                entity.ToTable("Tipo_Moneda");

                entity.Property(e => e.IdTipoMoneda).HasColumnName("idTipoMoneda");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(10)
                    .HasColumnName("descripcion")
                    .IsFixedLength(true);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(10)
                    .HasColumnName("nombre")
                    .IsFixedLength(true);

                entity.Property(e => e.Valor)
                    .HasColumnType("numeric(10, 3)")
                    .HasColumnName("valor");
            });

            modelBuilder.Entity<TipoOperacion>(entity =>
            {
                entity.HasKey(e => e.IdTipoOperacion);

                entity.ToTable("Tipo_Operacion");

                entity.Property(e => e.IdTipoOperacion).HasColumnName("idTipoOperacion");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(10)
                    .HasColumnName("descripcion")
                    .IsFixedLength(true);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.Tasa).HasColumnName("tasa");
            });

            modelBuilder.Entity<TipoServicio>(entity =>
            {
                entity.HasKey(e => e.IdTipoServicio);

                entity.ToTable("Tipo_Servicio");

                entity.Property(e => e.IdTipoServicio).HasColumnName("idTipoServicio");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(10)
                    .HasColumnName("descripcion")
                    .IsFixedLength(true);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(10)
                    .HasColumnName("nombre")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Transferencium>(entity =>
            {
                entity.HasKey(e => e.IdTransferencia);

                entity.Property(e => e.IdTransferencia).HasColumnName("idTransferencia");

                entity.Property(e => e.FechaOperacion)
                    .HasColumnType("date")
                    .HasColumnName("fechaOperacion");

                entity.Property(e => e.HoraOperacion)
                    .HasMaxLength(10)
                    .HasColumnName("horaOperacion")
                    .IsFixedLength(true);

                entity.Property(e => e.IdCuentaDestino).HasColumnName("idCuentaDestino");

                entity.Property(e => e.IdCuentaOrigen).HasColumnName("idCuentaOrigen");

                entity.Property(e => e.Monto)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("monto");

                entity.Property(e => e.Motivo)
                    .HasMaxLength(10)
                    .HasColumnName("motivo")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdCuentaDestinoNavigation)
                    .WithMany(p => p.TransferenciumIdCuentaDestinoNavigations)
                    .HasForeignKey(d => d.IdCuentaDestino)
                    .HasConstraintName("FK_Transferencia_CuentaDestino");

                entity.HasOne(d => d.IdCuentaOrigenNavigation)
                    .WithMany(p => p.TransferenciumIdCuentaOrigenNavigations)
                    .HasForeignKey(d => d.IdCuentaOrigen)
                    .HasConstraintName("FK_Transferencia_CuentaOrigin");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaAlta)
                    .HasColumnType("date")
                    .HasColumnName("fechaAlta");

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("nombreUsuario")
                    .IsFixedLength(true);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
