using GoToSPSWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoToSPSWebApi.DataContext.Map
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("categoria", "dbo");
            builder.HasKey(q => q.categoriaId);
            builder.Property(e => e.categoriaId).IsRequired().UseSqlServerIdentityColumn();
            builder.Property(e => e.categoriaNombre).HasColumnType("nvarchar(max)").IsRequired();
        }
    }
}
