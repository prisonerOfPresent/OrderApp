using Optional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Data.Repositories
{
    public interface IBaseRepository<TEntity, TIdentity>
    {
        Task<List<TEntity>> FindAll();
        Task<Option<TEntity>> FindByID(TIdentity id);
        Task<Option<TEntity>> Save(TEntity entity);
        Task<List<TEntity>> SaveAll(List<TEntity> entities);
        Task<Option<TEntity>> Update(TEntity entity);
        Task<Option<TEntity>> Modify(TEntity entity);
        Task<bool> Delete(TEntity entity);
        Task<bool> DeleteAll();
        Task<bool> DeleteInBatch(List<TEntity> entitiesToDelete);
    }
}
