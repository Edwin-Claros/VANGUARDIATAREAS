﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bitacora.API.Data;

namespace bitacora.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20191027180047_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0");

            modelBuilder.Entity("bitacora.API.Models.Bitacora", b =>
                {
                    b.Property<int>("bitacoraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("bitacoraFecha")
                        .HasColumnType("DateTime");

                    b.Property<DateTime>("bitacoraHoraFinal")
                        .HasColumnType("DateTime");

                    b.Property<DateTime>("bitacoraHoraInicio")
                        .HasColumnType("DateTime");

                    b.Property<int>("category_Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("bitacoraId");

                    b.HasIndex("category_Id");

                    b.ToTable("Bitacora","dbo");
                });

            modelBuilder.Entity("bitacora.API.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("bitacora.API.Models.Bitacora", b =>
                {
                    b.HasOne("bitacora.API.Models.Category", "Category")
                        .WithMany("Bitacoras")
                        .HasForeignKey("category_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
