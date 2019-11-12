using calculadora.API.Models;
using Microsoft.EntityFrameworkCore;

namespace calculadora.API.Data
{
    public class MultiplicarMap :IEntityTypeConfiguration<Multiplicar>
    {
         public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Multiplicar> builder)
        {
            builder.ToTable("multiplicar", "dbo");
            builder.HasKey(q => q.multiplicarlId);
            builder.Property(e => e.multiplicarlId).IsRequired().UseSqlServerIdentityColumn();
            builder.Property(e => e.multiplicarHistorico).HasColumnType("nvarchar(max)").IsRequired();
         }
    }
}