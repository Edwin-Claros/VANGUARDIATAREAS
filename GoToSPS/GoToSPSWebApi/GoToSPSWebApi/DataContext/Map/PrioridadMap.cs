using GoToSPSWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoToSPSWebApi.DataContext.Map
{
    public class PrioridadMap : IEntityTypeConfiguration<Prioridad>
    {
        public void Configure(EntityTypeBuilder<Prioridad> builder)
        {
            builder.ToTable("prioridad", "dbo");
            builder.HasKey(q => q.prioridadId);
            builder.Property(e => e.prioridadId).IsRequired().UseSqlServerIdentityColumn();
            builder.Property(e => e.prioridadNombre).HasColumnType("nvarchar(max)").IsRequired();
        }
    }
}
