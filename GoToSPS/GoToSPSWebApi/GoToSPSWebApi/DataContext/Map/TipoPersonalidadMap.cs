using GoToSPSWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoToSPSWebApi.DataContext.Map
{
    public class TipoPersonalidadMap : IEntityTypeConfiguration<TipoPersonalidad>
    {
        public void Configure(EntityTypeBuilder<TipoPersonalidad> builder)
        {
            builder.ToTable("tipoPersonalidad", "dbo");
            builder.HasKey(q => q.tipoPersonalidadId);
            builder.Property(e => e.tipoPersonalidadId).IsRequired().UseSqlServerIdentityColumn();
            builder.Property(e => e.tipoPersonalidadNombre).HasColumnType("nvarchar(max)").IsRequired();
        }
    }
}
