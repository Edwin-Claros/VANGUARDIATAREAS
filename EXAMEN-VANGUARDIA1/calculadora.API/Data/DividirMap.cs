using calculadora.API.Models;
using Microsoft.EntityFrameworkCore;

namespace calculadora.API.Data
{
    public class DividirMap : IEntityTypeConfiguration<Dividir>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Dividir> builder)
        {
            builder.ToTable("dividir", "dbo");
            builder.HasKey(q => q.dividirId);
            builder.Property(e => e.dividirId).IsRequired().UseSqlServerIdentityColumn();
            builder.Property(e => e.dividirHistorico).HasColumnType("nvarchar(max)").IsRequired();
         }
    }
}