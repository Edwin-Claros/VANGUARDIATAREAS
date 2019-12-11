﻿// <auto-generated />
using System;
using GoToSPSWebApi.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GoToSPSWebApi.Migrations
{
    [DbContext(typeof(GoToSPSContext))]
    partial class GoToSPSContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GoToSPSWebApi.Models.Actividad", b =>
                {
                    b.Property<int>("actividadId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("actividadDescripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("actividadDuracion")
                        .HasColumnType("DateTime");

                    b.Property<string>("actividadHorario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("actividadNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("categoria_Id");

                    b.Property<int>("jornada_Id");

                    b.Property<int>("lugar_Id");

                    b.Property<int?>("usuarioId");

                    b.HasKey("actividadId");

                    b.HasIndex("categoria_Id");

                    b.HasIndex("jornada_Id");

                    b.HasIndex("lugar_Id");

                    b.HasIndex("usuarioId");

                    b.ToTable("actividad","dbo");
                });

            modelBuilder.Entity("GoToSPSWebApi.Models.Categoria", b =>
                {
                    b.Property<int>("categoriaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("categoriaNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("categoriaId");

                    b.ToTable("categoria","dbo");
                });

            modelBuilder.Entity("GoToSPSWebApi.Models.Ciudad", b =>
                {
                    b.Property<int>("ciudadId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ciudadNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ciudadId");

                    b.ToTable("ciudad","dbo");
                });

            modelBuilder.Entity("GoToSPSWebApi.Models.ItinerarioDetalle", b =>
                {
                    b.Property<int>("itinerarioDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("actividad_Id");

                    b.Property<int>("itinerarioEncabezado_Id");

                    b.Property<int>("prioridad_Id");

                    b.HasKey("itinerarioDetalleId");

                    b.HasIndex("actividad_Id");

                    b.HasIndex("itinerarioEncabezado_Id");

                    b.HasIndex("prioridad_Id");

                    b.ToTable("itinerarioDetalle","dbo");
                });

            modelBuilder.Entity("GoToSPSWebApi.Models.ItinerarioEncabezado", b =>
                {
                    b.Property<int>("itinerarioEncabezadoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ciudad_Id");

                    b.Property<DateTime>("itinerarioEncabezadoFechaFinal")
                        .HasColumnType("DateTime");

                    b.Property<DateTime>("itinerarioEncabezadoFechaInicio")
                        .HasColumnType("DateTime");

                    b.Property<string>("itinerarioEncabezadoNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("lugar_Id");

                    b.HasKey("itinerarioEncabezadoId");

                    b.HasIndex("ciudad_Id");

                    b.HasIndex("lugar_Id");

                    b.ToTable("itinerarioEncabezado","dbo");
                });

            modelBuilder.Entity("GoToSPSWebApi.Models.Jornada", b =>
                {
                    b.Property<int>("jornadaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("jornadaNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("jornadaId");

                    b.ToTable("jornada","dbo");
                });

            modelBuilder.Entity("GoToSPSWebApi.Models.Lugar", b =>
                {
                    b.Property<int>("lugarId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ciudad_Id");

                    b.Property<string>("lugarFoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("lugarHoraCierre")
                        .HasColumnType("DateTime");

                    b.Property<DateTime>("lugarHoraEntrada")
                        .HasColumnType("DateTime");

                    b.Property<string>("lugarNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("lugarId");

                    b.HasIndex("ciudad_Id");

                    b.ToTable("lugar","dbo");
                });

            modelBuilder.Entity("GoToSPSWebApi.Models.Prioridad", b =>
                {
                    b.Property<int>("prioridadId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("prioridadNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("prioridadId");

                    b.ToTable("prioridad","dbo");
                });

            modelBuilder.Entity("GoToSPSWebApi.Models.TipoUsuario", b =>
                {
                    b.Property<int>("tipoUsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("tipoUsuarioNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("tipoUsuarioId");

                    b.ToTable("tipoUsuario","dbo");
                });

            modelBuilder.Entity("GoToSPSWebApi.Models.Usuario", b =>
                {
                    b.Property<int>("usuarioId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("tipoUsuario_Id");

                    b.Property<string>("usuarioClave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("usuarioNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("usuarioSexo")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)))
                        .HasColumnType("char");

                    b.HasKey("usuarioId");

                    b.HasIndex("tipoUsuario_Id");

                    b.ToTable("usuario","dbo");
                });

            modelBuilder.Entity("GoToSPSWebApi.Models.Actividad", b =>
                {
                    b.HasOne("GoToSPSWebApi.Models.Categoria", "Categoria")
                        .WithMany("Actividades")
                        .HasForeignKey("categoria_Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GoToSPSWebApi.Models.Jornada", "Jornada")
                        .WithMany("Actividades")
                        .HasForeignKey("jornada_Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GoToSPSWebApi.Models.Lugar", "Lugar")
                        .WithMany("Actividades")
                        .HasForeignKey("lugar_Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GoToSPSWebApi.Models.Usuario")
                        .WithMany("Actividades")
                        .HasForeignKey("usuarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("GoToSPSWebApi.Models.ItinerarioDetalle", b =>
                {
                    b.HasOne("GoToSPSWebApi.Models.Actividad", "Actividad")
                        .WithMany("ItinerarioDetalles")
                        .HasForeignKey("actividad_Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GoToSPSWebApi.Models.ItinerarioEncabezado", "ItinerarioEncabezado")
                        .WithMany("ItinerarioDetalles")
                        .HasForeignKey("itinerarioEncabezado_Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GoToSPSWebApi.Models.Prioridad", "Prioridad")
                        .WithMany("ItinerarioDetalles")
                        .HasForeignKey("prioridad_Id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("GoToSPSWebApi.Models.ItinerarioEncabezado", b =>
                {
                    b.HasOne("GoToSPSWebApi.Models.Ciudad", "Ciudad")
                        .WithMany("ItinerarioEncabezados")
                        .HasForeignKey("ciudad_Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GoToSPSWebApi.Models.Lugar", "Lugar")
                        .WithMany("ItinerarioEncabezado")
                        .HasForeignKey("lugar_Id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("GoToSPSWebApi.Models.Lugar", b =>
                {
                    b.HasOne("GoToSPSWebApi.Models.Ciudad", "Ciudad")
                        .WithMany("Lugares")
                        .HasForeignKey("ciudad_Id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("GoToSPSWebApi.Models.Usuario", b =>
                {
                    b.HasOne("GoToSPSWebApi.Models.TipoUsuario", "TipoUsuario")
                        .WithMany("Usuarios")
                        .HasForeignKey("tipoUsuario_Id")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
