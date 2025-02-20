using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace ConsoleApp1.Models;

public partial class CochesContext : DbContext
{
    public CochesContext()
    {
    }

    public CochesContext(DbContextOptions<CochesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alquilere> Alquileres { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Coch> Coches { get; set; }

    public virtual DbSet<CochesSeguro> CochesSeguros { get; set; }

    public virtual DbSet<ComprasRepuesto> ComprasRepuestos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Finanza> Finanzas { get; set; }

   

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Modelo> Modelos { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<Reparacione> Reparaciones { get; set; }

    public virtual DbSet<ReparacionesRepuesto> ReparacionesRepuestos { get; set; }

    public virtual DbSet<Repuesto> Repuestos { get; set; }

    public virtual DbSet<Seguro> Seguros { get; set; }

    public virtual DbSet<Tallere> Talleres { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=coches;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Alquilere>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("alquileres");

            entity.HasIndex(e => e.IdCliente, "id_cliente");

            entity.HasIndex(e => e.IdCoche, "id_coche");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.IdCliente)
                .HasColumnType("int(11)")
                .HasColumnName("id_cliente");
            entity.Property(e => e.IdCoche)
                .HasColumnType("int(11)")
                .HasColumnName("id_coche");
            entity.Property(e => e.PrecioTotal)
                .HasPrecision(10, 2)
                .HasColumnName("precio_total");

        

        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("clientes");

            entity.HasIndex(e => e.Dni, "dni").IsUnique();

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Dni)
                .HasMaxLength(9)
                .HasColumnName("dni");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Coch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("coches");

            entity.HasIndex(e => e.id_modelo, "id_modelo");

            entity.HasIndex(e => e.Matricula, "matricula").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Anio)
                .HasColumnType("int(11)")
                .HasColumnName("anio");
            entity.Property(e => e.Color)
                .HasMaxLength(20)
                .HasColumnName("color");
            entity.Property(e => e.id_modelo)
                .HasColumnType("int(11)")
                .HasColumnName("id_modelo");
            entity.Property(e => e.Matricula)
                .HasMaxLength(10)
                .HasColumnName("matricula");
            entity.Property(e => e.Precio)
                .HasPrecision(10, 2)
                .HasColumnName("precio");

            
        });

        modelBuilder.Entity<CochesSeguro>(entity =>
        {
            entity.HasKey(e => new { e.IdCoche, e.IdSeguro })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("coches_seguros");

            entity.HasIndex(e => e.IdSeguro, "id_seguro");

            entity.Property(e => e.IdCoche)
                .HasColumnType("int(11)")
                .HasColumnName("id_coche");
            entity.Property(e => e.IdSeguro)
                .HasColumnType("int(11)")
                .HasColumnName("id_seguro");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");

         

            entity.HasOne(d => d.IdSeguroNavigation).WithMany(p => p.CochesSeguros)
                .HasForeignKey(d => d.IdSeguro)
                .HasConstraintName("coches_seguros_ibfk_2");
        });

        modelBuilder.Entity<ComprasRepuesto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("compras_repuestos");

            entity.HasIndex(e => e.IdProveedor, "id_proveedor");

            entity.HasIndex(e => e.IdRepuesto, "id_repuesto");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Cantidad)
                .HasColumnType("int(11)")
                .HasColumnName("cantidad");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdProveedor)
                .HasColumnType("int(11)")
                .HasColumnName("id_proveedor");
            entity.Property(e => e.IdRepuesto)
                .HasColumnType("int(11)")
                .HasColumnName("id_repuesto");
            entity.Property(e => e.PrecioTotal)
                .HasPrecision(10, 2)
                .HasColumnName("precio_total");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.ComprasRepuestos)
                .HasForeignKey(d => d.IdProveedor)
                .HasConstraintName("compras_repuestos_ibfk_1");

            entity.HasOne(d => d.IdRepuestoNavigation).WithMany(p => p.ComprasRepuestos)
                .HasForeignKey(d => d.IdRepuesto)
                .HasConstraintName("compras_repuestos_ibfk_2");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("empleados");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Puesto)
                .HasMaxLength(50)
                .HasColumnName("puesto");
            entity.Property(e => e.Salario)
                .HasPrecision(10, 2)
                .HasColumnName("salario");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Finanza>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("finanzas");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Concepto)
                .HasMaxLength(255)
                .HasColumnName("concepto");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Monto)
                .HasPrecision(10, 2)
                .HasColumnName("monto");
            entity.Property(e => e.Tipo)
                .HasColumnType("enum('Ingreso','Egreso')")
                .HasColumnName("tipo");
        });


        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("marcas");

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Modelo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("modelos");

            entity.HasIndex(e => e.IdMarca, "id_marca");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.IdMarca)
                .HasColumnType("int(11)")
                .HasColumnName("id_marca");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdMarcaNavigation).WithMany(p => p.Modelos)
                .HasForeignKey(d => d.IdMarca)
                .HasConstraintName("modelos_ibfk_1");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("proveedores");

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Reparacione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("reparaciones");

            entity.HasIndex(e => e.IdCoche, "id_coche");

            entity.HasIndex(e => e.IdTaller, "id_taller");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Costo)
                .HasPrecision(10, 2)
                .HasColumnName("costo");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdCoche)
                .HasColumnType("int(11)")
                .HasColumnName("id_coche");
            entity.Property(e => e.IdTaller)
                .HasColumnType("int(11)")
                .HasColumnName("id_taller");


            entity.HasOne(d => d.IdTallerNavigation).WithMany(p => p.Reparaciones)
                .HasForeignKey(d => d.IdTaller)
                .HasConstraintName("reparaciones_ibfk_2");
        });

        modelBuilder.Entity<ReparacionesRepuesto>(entity =>
        {
            entity.HasKey(e => new { e.IdReparacion, e.IdRepuesto })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("reparaciones_repuestos");

            entity.HasIndex(e => e.IdRepuesto, "id_repuesto");

            entity.Property(e => e.IdReparacion)
                .HasColumnType("int(11)")
                .HasColumnName("id_reparacion");
            entity.Property(e => e.IdRepuesto)
                .HasColumnType("int(11)")
                .HasColumnName("id_repuesto");
            entity.Property(e => e.Cantidad)
                .HasColumnType("int(11)")
                .HasColumnName("cantidad");

            entity.HasOne(d => d.IdReparacionNavigation).WithMany(p => p.ReparacionesRepuestos)
                .HasForeignKey(d => d.IdReparacion)
                .HasConstraintName("reparaciones_repuestos_ibfk_1");

            entity.HasOne(d => d.IdRepuestoNavigation).WithMany(p => p.ReparacionesRepuestos)
                .HasForeignKey(d => d.IdRepuesto)
                .HasConstraintName("reparaciones_repuestos_ibfk_2");
        });

        modelBuilder.Entity<Repuesto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("repuestos");

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasPrecision(10, 2)
                .HasColumnName("precio");
            entity.Property(e => e.Stock)
                .HasColumnType("int(11)")
                .HasColumnName("stock");
        });

        modelBuilder.Entity<Seguro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("seguros");

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Cobertura)
                .HasColumnType("text")
                .HasColumnName("cobertura");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Tallere>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("talleres");

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .HasColumnName("telefono");
        });

       

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
