using GoToSPSWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoToSPSWebApi.DataContext.Map
{
    public class TipoAmbienteMap : IEntityTypeConfiguration<TipoAmbiente>
    {
        public void Configure(EntityTypeBuilder<TipoAmbiente> builder)
        {
            builder.ToTable("tipoAmbiente", "dbo");
            builder.HasKey(q => q.tipoAmbienteId);
            builder.Property(e => e.tipoAmbienteId).IsRequired().UseSqlServerIdentityColumn();
            builder.Property(e => e.tipoAmbienteNombre).HasColumnType("nvarchar(max)").IsRequired();
        }
    }
}
