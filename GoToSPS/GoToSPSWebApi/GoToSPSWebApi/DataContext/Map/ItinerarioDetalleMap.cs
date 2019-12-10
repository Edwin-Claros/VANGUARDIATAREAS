using GoToSPSWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoToSPSWebApi.DataContext.Map
{
    public class ItinerarioDetalleMap : IEntityTypeConfiguration<ItinerarioDetalle>
    {
        public void Configure(EntityTypeBuilder<ItinerarioDetalle> builder)
        {
            builder.ToTable("itinerarioDetalle", "dbo");
            builder.HasKey(q => q.itinerarioDetalleId);
            builder.Property(e => e.itinerarioDetalleId).IsRequired().UseSqlServerIdentityColumn();

            builder.HasOne(e => e.Actividad).WithMany(e => e.ItinerarioDetalles).HasForeignKey(e => e.actividad_Id).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.Prioridad).WithMany(e => e.ItinerarioDetalles).HasForeignKey(e => e.prioridad_Id).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.ItinerarioEncabezado).WithMany(e => e.ItinerarioDetalles).HasForeignKey(e => e.itinerarioEncabezado_Id).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
