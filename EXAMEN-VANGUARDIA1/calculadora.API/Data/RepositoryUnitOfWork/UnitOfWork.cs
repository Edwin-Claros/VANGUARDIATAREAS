using System.Threading.Tasks;

namespace calculadora.API.Data.RepositoryUnitOfWork
{
   public class UnitOfWork : IUnitOfWork
    {

        private readonly DataContext _context;

        public IDividirRepository Dividir { get; }
        public IExponencialRepository Exponencial { get; }
        public IMultiplicarRepository Multiplicar { get; }
        public IRaizRepository Raiz { get; }
        public IRestarRepository Restar { get; }
        public ISumarRepository Sumar { get; }


        public UnitOfWork(DataContext context)
        {
            _context = context;
            Dividir = new DividirRepository(_context);
            Exponencial = new ExponencialRepository(_context);
            Multiplicar = new MultiplicarRepository(_context);
            Raiz = new RaizRepository(_context);
            Restar = new RestarRepository(_context);
            Sumar = new SumarRepository(_context);
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}