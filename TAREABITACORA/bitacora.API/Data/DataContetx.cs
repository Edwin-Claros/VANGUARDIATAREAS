using Microsoft.EntityFrameworkCore;
using bitacora.API.Models;
using System.Linq;

namespace bitacora.API.Data
{
     public class DataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Bitacora> Bitacoras { get; set; }
        public DataContext(DbContextOptions<DataContext>options):base(options)
        {
            
        }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new BitacoraMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());

           foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}