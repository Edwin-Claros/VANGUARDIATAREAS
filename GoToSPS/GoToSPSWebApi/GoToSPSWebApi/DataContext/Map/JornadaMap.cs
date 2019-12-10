using GoToSPSWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoToSPSWebApi.DataContext.Map
{
    public class JornadaMap : IEntityTypeConfiguration<Jornada>
    {
        public void Configure(EntityTypeBuilder<Jornada> builder)
        {
            builder.ToTable("jornada", "dbo");
            builder.HasKey(q => q.jornadaId);
            builder.Property(e => e.jornadaId).IsRequired().UseSqlServerIdentityColumn();
            builder.Property(e => e.jornadaNombre).HasColumnType("nvarchar(max)").IsRequired();
        }
    }
}
