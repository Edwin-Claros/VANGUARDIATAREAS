using calculadora.API.Models;
using Microsoft.EntityFrameworkCore;

namespace calculadora.API.Data
{
    public class SumarMap : IEntityTypeConfiguration<Sumar>
    {
         public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Sumar> builder)
        {
            builder.ToTable("sumar", "dbo");
            builder.HasKey(q => q.sumarlId);
            builder.Property(e => e.sumarlId).IsRequired().UseSqlServerIdentityColumn();
            builder.Property(e => e.sumarHistorico).HasColumnType("nvarchar(max)").IsRequired();
         }
    }
}