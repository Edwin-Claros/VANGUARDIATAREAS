using bitacora.API.Models;
using Microsoft.EntityFrameworkCore;

namespace bitacora.API.Data
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
         public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category", "dbo");
            builder.HasKey(q => q.categoryId);
            builder.Property(e => e.categoryId).IsRequired().UseSqlServerIdentityColumn();
            builder.Property(e => e.categoryNombre).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(e => e.categoryDescripcion).HasColumnType("nvarchar(max)").IsRequired();
        }
    }
}