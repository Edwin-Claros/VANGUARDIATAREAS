using calculadora.API.Models;
using Microsoft.EntityFrameworkCore;

namespace calculadora.API.Data
{
    public class RestarMap : IEntityTypeConfiguration<Restar>
    {
         public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Restar> builder)
        {
            builder.ToTable("restar", "dbo");
            builder.HasKey(q => q.restarlId);
            builder.Property(e => e.restarlId).IsRequired().UseSqlServerIdentityColumn();
            builder.Property(e => e.restarlHistorico).HasColumnType("nvarchar(max)").IsRequired();
         }
    }
}