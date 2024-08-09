﻿// <auto-generated />
using System;
using BackendEstadistica.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackendEstadistica.Migrations
{
    [DbContext(typeof(ContextoBBDD))]
    partial class ContextoBBDDModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BackendEstadistica.Entidades.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<string>("Contraseña")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaisId")
                        .HasColumnType("int");

                    b.Property<string>("Sexo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trabajo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.HasIndex("PaisId")
                        .IsUnique();

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("BackendEstadistica.Entidades.Conversion", b =>
                {
                    b.Property<int>("ConversionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConversionId"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("MonedaDestino")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MonedaOrigen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("ValorDestino")
                        .HasColumnType("float");

                    b.Property<double?>("ValorOrigen")
                        .HasColumnType("float");

                    b.HasKey("ConversionId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Conversion");
                });

            modelBuilder.Entity("BackendEstadistica.Entidades.Pais", b =>
                {
                    b.Property<int>("PaisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaisId"));

                    b.Property<string>("Divisa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PaisId");

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("BackendEstadistica.Entidades.Transaccion", b =>
                {
                    b.Property<int>("TransaccionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransaccionId"));

                    b.Property<int>("ClienteDestinoId")
                        .HasColumnType("int");

                    b.Property<int>("ClienteOrigenId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<double?>("ImporteEnviado")
                        .HasColumnType("float");

                    b.Property<double?>("ImporteRecibido")
                        .HasColumnType("float");

                    b.HasKey("TransaccionId");

                    b.HasIndex("ClienteDestinoId");

                    b.HasIndex("ClienteOrigenId");

                    b.ToTable("Transacciones");
                });

            modelBuilder.Entity("BackendEstadistica.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contraseña")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("BackendEstadistica.Entidades.Cliente", b =>
                {
                    b.HasOne("BackendEstadistica.Entidades.Pais", "Pais")
                        .WithOne("Cliente")
                        .HasForeignKey("BackendEstadistica.Entidades.Cliente", "PaisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("BackendEstadistica.Entidades.Conversion", b =>
                {
                    b.HasOne("BackendEstadistica.Entidades.Cliente", "Cliente")
                        .WithMany("Conversiones")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("BackendEstadistica.Entidades.Transaccion", b =>
                {
                    b.HasOne("BackendEstadistica.Entidades.Cliente", "ClienteDestino")
                        .WithMany("TransaccionesDestino")
                        .HasForeignKey("ClienteDestinoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BackendEstadistica.Entidades.Cliente", "ClienteOrigen")
                        .WithMany("TransaccionesOrigen")
                        .HasForeignKey("ClienteOrigenId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ClienteDestino");

                    b.Navigation("ClienteOrigen");
                });

            modelBuilder.Entity("BackendEstadistica.Entidades.Cliente", b =>
                {
                    b.Navigation("Conversiones");

                    b.Navigation("TransaccionesDestino");

                    b.Navigation("TransaccionesOrigen");
                });

            modelBuilder.Entity("BackendEstadistica.Entidades.Pais", b =>
                {
                    b.Navigation("Cliente");
                });
#pragma warning restore 612, 618
        }
    }
}
