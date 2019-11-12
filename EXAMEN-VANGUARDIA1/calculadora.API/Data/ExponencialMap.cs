using calculadora.API.Models;
using Microsoft.EntityFrameworkCore;

namespace calculadora.API.Data
{
    public class ExponencialMap : IEntityTypeConfiguration<Exponencial>
    {
         public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Exponencial> builder)
        {
            builder.ToTable("exponencial", "dbo");
            builder.HasKey(q => q.exponencialId);
            builder.Property(e => e.exponencialId).IsRequired().UseSqlServerIdentityColumn();
            builder.Property(e => e.exponencialHistorico).HasColumnType("nvarchar(max)").IsRequired();
         }
    }
}