using GoToSPSWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoToSPSWebApi.DataContext.Map
{
    public class TipoUsuarioMap : IEntityTypeConfiguration<TipoUsuario>
    {
        public void Configure(EntityTypeBuilder<TipoUsuario> builder)
        {
            builder.ToTable("tipoUsuario", "dbo");
            builder.HasKey(q => q.tipoUsuarioId);
            builder.Property(e => e.tipoUsuarioId).IsRequired().UseSqlServerIdentityColumn();
            builder.Property(e => e.tipoUsuarioNombre).HasColumnType("nvarchar(max)").IsRequired();
        }
    }
}
