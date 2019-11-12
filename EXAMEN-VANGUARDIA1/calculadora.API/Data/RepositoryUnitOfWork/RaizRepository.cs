using System;
using calculadora.API.Models;

namespace calculadora.API.Data.RepositoryUnitOfWork
{
    public class RaizRepository: GenericRepository<Raiz>, IRaizRepository
    {
        private readonly DataContext _context;
        public RaizRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}