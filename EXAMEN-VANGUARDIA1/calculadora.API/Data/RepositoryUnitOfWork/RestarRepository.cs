using System;
using calculadora.API.Models;

namespace calculadora.API.Data.RepositoryUnitOfWork
{
    public class RestarRepository: GenericRepository<Restar>, IRestarRepository
    {
        private readonly DataContext _context;
        public RestarRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
