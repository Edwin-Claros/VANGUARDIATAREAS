using calculadora.API.Models;
using Microsoft.EntityFrameworkCore;

namespace calculadora.API.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Sumar> Sumar { get; set; }
        public DbSet<Restar> Restar { get; set; }
        public DbSet<Raiz> Raiz { get; set; }
        public DbSet<Multiplicar> Multiplicar { get; set; }
        public DbSet<Exponencial> Exponencial { get; set; }
        public DbSet<Dividir> Dividir { get; set; }

        public DataContext(DbContextOptions<DataContext>options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DividirMap());
            modelBuilder.ApplyConfiguration(new ExponencialMap());
            modelBuilder.ApplyConfiguration(new MultiplicarMap());
            modelBuilder.ApplyConfiguration(new RaizMap());
            modelBuilder.ApplyConfiguration(new RestarMap());
            modelBuilder.ApplyConfiguration(new SumarMap());

            base.OnModelCreating(modelBuilder);
            
        }
    }
}