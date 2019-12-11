using GoToSPSWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoToSPSWebApi.DataContext.Map
{
    public class EstadoCivilMap : IEntityTypeConfiguration<EstadoCivil>
    {
        public void Configure(EntityTypeBuilder<EstadoCivil> builder)
        {
            builder.ToTable("estadoCivil", "dbo");
            builder.HasKey(q => q.estadoCivilId);
            builder.Property(e => e.estadoCivilId).IsRequired().UseSqlServerIdentityColumn();
            builder.Property(e => e.estadoCivilNombre).HasColumnType("nvarchar(max)").IsRequired();
        }
    }
}
