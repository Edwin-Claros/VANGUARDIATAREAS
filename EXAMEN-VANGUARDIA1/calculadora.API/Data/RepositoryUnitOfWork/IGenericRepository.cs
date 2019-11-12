using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace calculadora.API.Data.RepositoryUnitOfWork
{
   public interface IGenericRepository<T> where T : class
    {
         Task Add(T entity);         
         Task Delete(object id);
         Task<ActionResult<IEnumerable<T>>> GetAll();
         Task<T> GetById(object id);          
         T Update(int id, T entity);

         bool Exists(object id);
    }
}