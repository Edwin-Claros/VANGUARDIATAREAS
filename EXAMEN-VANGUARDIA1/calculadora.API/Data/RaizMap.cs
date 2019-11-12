using calculadora.API.Models;
using Microsoft.EntityFrameworkCore;

namespace calculadora.API.Data
{
    public class RaizMap : IEntityTypeConfiguration<Raiz>
    {
         public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Raiz> builder)
        {
            builder.ToTable("raiz", "dbo");
            builder.HasKey(q => q.raizlId);
            builder.Property(e => e.raizlId).IsRequired().UseSqlServerIdentityColumn();
            builder.Property(e => e.raizHistorico).HasColumnType("nvarchar(max)").IsRequired();
         }
    }
}