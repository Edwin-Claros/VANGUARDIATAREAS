using Microsoft.EntityFrameworkCore;
using tarea1.API.Models;

namespace tarea1.API.DataContext
{
    public class DataContextUser : DbContext
    {
        
        public DbSet<User> Users { get; set; }

    public DataContextUser(DbContextOptions<DataContextUser> options): base(options)
    {

    }

    }

}