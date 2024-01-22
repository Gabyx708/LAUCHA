﻿// <auto-generated />
using System;
using LAUCHA.infrastructure.persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LAUCHA.infrastructure.Migrations
{
    [DbContext(typeof(LiquidacionesDbContext))]
    partial class LiquidacionesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LAUCHA.domain.entities.Contrato", b =>
                {
                    b.Property<string>("CodigoContrato")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DniEmpleado")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<decimal>("FechaContrato")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Modalidad")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("MontoPorHora")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TipoContrato")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CodigoContrato");

                    b.HasIndex("DniEmpleado");

                    b.ToTable("Contratos");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Credito", b =>
                {
                    b.Property<string>("CodigoCredito")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Concepto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NumeroCuenta")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("CodigoCredito");

                    b.HasIndex("NumeroCuenta");

                    b.ToTable("Creditos");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Cuenta", b =>
                {
                    b.Property<string>("NumeroCuenta")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DniEmpleado")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("estadoCuenta")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("NumeroCuenta");

                    b.HasIndex("DniEmpleado")
                        .IsUnique();

                    b.ToTable("Cuentas");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Cuota", b =>
                {
                    b.Property<string>("CodigoCuota")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CodigoCredito")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("FechaDebePagar")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CodigoCuota");

                    b.HasIndex("CodigoCredito");

                    b.ToTable("Cuotas");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.DescuentoFijo", b =>
                {
                    b.Property<string>("CodigoDescuento")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Concepto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Unidades")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CodigoDescuento");

                    b.ToTable("DescuentosFijos");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.DescuentoFijoPorCuenta", b =>
                {
                    b.Property<string>("NumeroCuenta")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CodigoDescuento")
                        .HasColumnType("varchar(255)");

                    b.HasKey("NumeroCuenta", "CodigoDescuento");

                    b.HasIndex("CodigoDescuento");

                    b.ToTable("DescuentosFijoPorCuentas");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Empleado", b =>
                {
                    b.Property<string>("Dni")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Dni");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.HistorialDescuentoFijo", b =>
                {
                    b.Property<string>("CodigoDescuento")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("FechaFinVigencia")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Concepto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Unidades")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CodigoDescuento", "FechaFinVigencia");

                    b.ToTable("HistorialDescuentosFijos");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Liquidacion", b =>
                {
                    b.Property<string>("CodigoLiquidacion")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Concepto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("EgresoTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("IngresoTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CodigoLiquidacion");

                    b.ToTable("Liquidaciones");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.LiquidacionPorTransaccion", b =>
                {
                    b.Property<long>("NumeroTransaccion")
                        .HasColumnType("bigint");

                    b.Property<string>("CodigoLiquidacion")
                        .HasColumnType("varchar(255)");

                    b.HasKey("NumeroTransaccion", "CodigoLiquidacion");

                    b.HasIndex("CodigoLiquidacion");

                    b.ToTable("LiquidacionesPorTransacciones");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.PagoLiquidacion", b =>
                {
                    b.Property<int>("CodigoPago")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CodigoLiquidacion")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CodigoPago");

                    b.HasIndex("CodigoLiquidacion")
                        .IsUnique();

                    b.ToTable("PagosLiquidaciones");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Subcuota", b =>
                {
                    b.Property<string>("CodigoSubcuota")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CodigoCuota")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("FechaDebePagar")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CodigoSubcuota");

                    b.HasIndex("CodigoCuota");

                    b.ToTable("Subcuotas");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Transaccion", b =>
                {
                    b.Property<long>("NumeroTransaccion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Concepto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NumeroCuenta")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("Tipo")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("NumeroTransaccion");

                    b.HasIndex("NumeroCuenta");

                    b.ToTable("Transacciones");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Contrato", b =>
                {
                    b.HasOne("LAUCHA.domain.entities.Empleado", "Empleado")
                        .WithMany("Contratos")
                        .HasForeignKey("DniEmpleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Credito", b =>
                {
                    b.HasOne("LAUCHA.domain.entities.Cuenta", "Cuenta")
                        .WithMany("Creditos")
                        .HasForeignKey("NumeroCuenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuenta");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Cuenta", b =>
                {
                    b.HasOne("LAUCHA.domain.entities.Empleado", "Empleado")
                        .WithOne("Cuenta")
                        .HasForeignKey("LAUCHA.domain.entities.Cuenta", "DniEmpleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Cuota", b =>
                {
                    b.HasOne("LAUCHA.domain.entities.Credito", "Credito")
                        .WithMany("Cuotas")
                        .HasForeignKey("CodigoCredito")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Credito");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.DescuentoFijoPorCuenta", b =>
                {
                    b.HasOne("LAUCHA.domain.entities.DescuentoFijo", "DescuentoFijo")
                        .WithMany("DescuentosFijosPorCuenta")
                        .HasForeignKey("CodigoDescuento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LAUCHA.domain.entities.Cuenta", "Cuenta")
                        .WithMany("DescuentosFijosPorCuenta")
                        .HasForeignKey("NumeroCuenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuenta");

                    b.Navigation("DescuentoFijo");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.HistorialDescuentoFijo", b =>
                {
                    b.HasOne("LAUCHA.domain.entities.DescuentoFijo", "DescuentoFijo")
                        .WithMany("HistorialDescuentoFijos")
                        .HasForeignKey("CodigoDescuento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DescuentoFijo");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.LiquidacionPorTransaccion", b =>
                {
                    b.HasOne("LAUCHA.domain.entities.Liquidacion", "Liquidacion")
                        .WithMany("LiquidacionPorTransaccion")
                        .HasForeignKey("CodigoLiquidacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LAUCHA.domain.entities.Transaccion", "Transaccion")
                        .WithMany("LiquidacionPorTransaccion")
                        .HasForeignKey("NumeroTransaccion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Liquidacion");

                    b.Navigation("Transaccion");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.PagoLiquidacion", b =>
                {
                    b.HasOne("LAUCHA.domain.entities.Liquidacion", "Liquidacion")
                        .WithOne("PagoLiquidacion")
                        .HasForeignKey("LAUCHA.domain.entities.PagoLiquidacion", "CodigoLiquidacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Liquidacion");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Subcuota", b =>
                {
                    b.HasOne("LAUCHA.domain.entities.Cuota", "Cuota")
                        .WithMany("Subcuotas")
                        .HasForeignKey("CodigoCuota")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuota");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Transaccion", b =>
                {
                    b.HasOne("LAUCHA.domain.entities.Cuenta", "Cuenta")
                        .WithMany("Transacciones")
                        .HasForeignKey("NumeroCuenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuenta");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Credito", b =>
                {
                    b.Navigation("Cuotas");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Cuenta", b =>
                {
                    b.Navigation("Creditos");

                    b.Navigation("DescuentosFijosPorCuenta");

                    b.Navigation("Transacciones");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Cuota", b =>
                {
                    b.Navigation("Subcuotas");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.DescuentoFijo", b =>
                {
                    b.Navigation("DescuentosFijosPorCuenta");

                    b.Navigation("HistorialDescuentoFijos");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Empleado", b =>
                {
                    b.Navigation("Contratos");

                    b.Navigation("Cuenta")
                        .IsRequired();
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Liquidacion", b =>
                {
                    b.Navigation("LiquidacionPorTransaccion");

                    b.Navigation("PagoLiquidacion")
                        .IsRequired();
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Transaccion", b =>
                {
                    b.Navigation("LiquidacionPorTransaccion");
                });
#pragma warning restore 612, 618
        }
    }
}
