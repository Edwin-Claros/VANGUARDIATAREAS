using System;
using System.Threading.Tasks;

namespace calculadora.API.Data.RepositoryUnitOfWork
{
   public interface IUnitOfWork : IDisposable
    {
        public IDividirRepository Dividir { get; }
        public IExponencialRepository Exponencial { get; }
        public IMultiplicarRepository Multiplicar { get; }
        public IRaizRepository Raiz { get; }
        public IRestarRepository Restar { get; }
        public ISumarRepository Sumar { get; }

         Task<int> Complete();
    }
}