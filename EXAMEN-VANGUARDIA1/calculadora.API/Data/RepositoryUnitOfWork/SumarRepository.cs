using System;
using calculadora.API.Models;

namespace calculadora.API.Data.RepositoryUnitOfWork
{
    public class SumarRepository: GenericRepository<Sumar>, ISumarRepository
    {
        private readonly DataContext _context;
        public SumarRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
