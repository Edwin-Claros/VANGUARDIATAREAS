using GoToSPSWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoToSPSWebApi.DataContext.Map
{
    public class ActividadMap : IEntityTypeConfiguration<Actividad>
    {
        public void Configure(EntityTypeBuilder<Actividad> builder)
        {
            builder.ToTable("actividad", "dbo");
            builder.HasKey(q => q.actividadId);
            builder.Property(e => e.actividadId).IsRequired().UseSqlServerIdentityColumn();
            builder.Property(e => e.actividadNombre).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(e => e.actividadDescripcion).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(e => e.actividadHorario).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(e => e.actividadDuracion).HasColumnType("DateTime").IsRequired();

            builder.HasOne(e => e.Lugar).WithMany(e => e.Actividades).HasForeignKey(e => e.lugar_Id).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.Categoria).WithMany(e => e.Actividades).HasForeignKey(e => e.categoria_Id).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.Jornada).WithMany(e => e.Actividades).HasForeignKey(e => e.jornada_Id).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
