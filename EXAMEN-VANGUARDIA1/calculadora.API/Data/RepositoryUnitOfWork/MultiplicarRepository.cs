using System;
using calculadora.API.Models;

namespace calculadora.API.Data.RepositoryUnitOfWork
{
    public class MultiplicarRepository: GenericRepository<Multiplicar>, IMultiplicarRepository
    {
        private readonly DataContext _context;
        public MultiplicarRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}