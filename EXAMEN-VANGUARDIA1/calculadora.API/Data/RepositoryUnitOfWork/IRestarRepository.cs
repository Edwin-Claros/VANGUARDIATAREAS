using System;
using calculadora.API.Models;

namespace calculadora.API.Data.RepositoryUnitOfWork
{
    public interface IRestarRepository : IGenericRepository<Restar>, IDisposable
    {
        
    }
}