using System;
using calculadora.API.Models;

namespace calculadora.API.Data.RepositoryUnitOfWork
{
    public class DividirRepository : GenericRepository<Dividir>, IDividirRepository
    {
        private readonly DataContext _context;
        public DividirRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        
    }
}