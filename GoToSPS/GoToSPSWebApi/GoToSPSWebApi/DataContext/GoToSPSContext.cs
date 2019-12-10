using GoToSPSWebApi.DataContext.Map;
using GoToSPSWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoToSPSWebApi.DataContext
{
    public class GoToSPSContext : DbContext
    {
        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<ItinerarioDetalle> ItinerarioDetalles { get; set; }
        public DbSet<ItinerarioEncabezado> ItinerarioEncabezados { get; set; }
        public DbSet<Jornada> Jornadas { get; set; }
        public DbSet<Prioridad> Prioridades { get; set; }
        public DbSet<Lugar> Lugares { get; set; }
        public DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
           //  optionBuilder.UseSqlServer(@"Server=EDWIN-CLAROS;DataBase=GoToSps;Trusted_Connection=True;");
            optionBuilder.UseSqlServer(@"Server=tcp:webapigestionproyecto120190830124340dbserver.database.windows.net,1433;Initial Catalog=GoToSPS;Persist Security Info=False;User ID=edwin.clarospineda@unitec.edu@webapigestionproyecto120190830124340dbserver;Password=Eclaros.206049;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new ActividadMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new ItinerarioDetalleMap());
            modelBuilder.ApplyConfiguration(new ItinerarioEncabezadoMap());
            modelBuilder.ApplyConfiguration(new JornadaMap());
            modelBuilder.ApplyConfiguration(new LugarMap());
            modelBuilder.ApplyConfiguration(new PrioridadMap());
            modelBuilder.ApplyConfiguration(new TipoUsuarioMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }
    }   
}
