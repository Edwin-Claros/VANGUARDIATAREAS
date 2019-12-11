using GoToSPSWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoToSPSWebApi.DataContext.Map
{
    public class LugarMap : IEntityTypeConfiguration<Lugar>
    {
        public void Configure(EntityTypeBuilder<Lugar> builder)
        {
            builder.ToTable("lugar", "dbo");
            builder.HasKey(q => q.lugarId);
            builder.Property(e => e.lugarId).IsRequired().UseSqlServerIdentityColumn();
            builder.Property(e => e.lugarNombre).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(e => e.lugarFoto).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(e => e.lugarHoraEntrada).HasColumnType("DateTime").IsRequired();
            builder.Property(e => e.lugarHoraCierre).HasColumnType("DateTime").IsRequired();

            builder.HasOne(e => e.Ciudad).WithMany(e => e.Lugares).HasForeignKey(e => e.ciudad_Id).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.TipoAmbiente).WithMany(e => e.Lugares).HasForeignKey(e => e.tipoAmbiente_Id).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
