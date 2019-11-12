using Microsoft.EntityFrameworkCore;

namespace bitacora.API.Data
{
    public class GenerycRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbSet<T> _entities;


    }
}