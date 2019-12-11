using GoToSPSWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoToSPSWebApi.DataContext.Map
{
    public class ItinerarioEncabezadoMap : IEntityTypeConfiguration<ItinerarioEncabezado>
    {
        public void Configure(EntityTypeBuilder<ItinerarioEncabezado> builder)
        {
            builder.ToTable("itinerarioEncabezado", "dbo");
            builder.HasKey(q => q.itinerarioEncabezadoId);
            builder.Property(e => e.itinerarioEncabezadoId).IsRequired().UseSqlServerIdentityColumn();
            builder.Property(e => e.itinerarioEncabezadoNombre).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(e => e.itinerarioEncabezadoFechaInicio).HasColumnType("DateTime").IsRequired();
            builder.Property(e => e.itinerarioEncabezadoFechaFinal).HasColumnType("DateTime").IsRequired();

            builder.HasOne(e => e.Lugar).WithMany(e => e.ItinerarioEncabezado).HasForeignKey(e => e.lugar_Id).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.Ciudad).WithMany(e => e.ItinerarioEncabezados).HasForeignKey(e => e.ciudad_Id).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.Usuario).WithMany(e => e.ItinerarioEncabezados).HasForeignKey(e => e.usuario_Id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
