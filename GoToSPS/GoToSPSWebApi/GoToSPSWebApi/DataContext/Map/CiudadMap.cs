using GoToSPSWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoToSPSWebApi.DataContext.Map
{
    public class CiudadMap : IEntityTypeConfiguration<Ciudad>
    {
        public void Configure(EntityTypeBuilder<Ciudad> builder)
        {
            builder.ToTable("ciudad", "dbo");
            builder.HasKey(q => q.ciudadId);
            builder.Property(e => e.ciudadId).IsRequired().UseSqlServerIdentityColumn();
            builder.Property(e => e.ciudadNombre).HasColumnType("nvarchar(max)").IsRequired();
        }
    }
}
