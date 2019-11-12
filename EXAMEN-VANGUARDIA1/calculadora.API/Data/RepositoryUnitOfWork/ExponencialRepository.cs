using System;
using calculadora.API.Models;

namespace calculadora.API.Data.RepositoryUnitOfWork
{
    public class ExponencialRepository: GenericRepository<Exponencial>, IExponencialRepository
    {
        private readonly DataContext _context;
        public ExponencialRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}