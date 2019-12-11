using GoToSPSWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoToSPSWebApi.DataContext.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario", "dbo");
            builder.HasKey(q => q.usuarioId);
            builder.Property(e => e.usuarioId).IsRequired().UseSqlServerIdentityColumn();
            builder.Property(e => e.usuarioNombre).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(e => e.usuarioClave).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(e => e.usuarioSexo).HasColumnType("char").IsRequired();
            builder.Property(e => e.usuarioFechaNacimiento).HasColumnType("DateTime").IsRequired();
            builder.Property(e => e.usuarioMedioTransporte).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(e => e.usuarioProfesion).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(e => e.usuarioInteres).HasColumnType("nvarchar(max)").IsRequired();

            builder.HasOne(e => e.TipoUsuario).WithMany(e => e.Usuarios).HasForeignKey(e => e.tipoUsuario_Id).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.TipoPersonalidad).WithMany(e => e.Usuarios).HasForeignKey(e => e.tipoPersonalidad_Id).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.EstadoCivil).WithMany(e => e.Usuarios).HasForeignKey(e => e.estadoCivil_Id).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.TipoAmbiente).WithMany(e => e.Usuarios).HasForeignKey(e => e.tipoAmbiente_Id).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
