using Optional;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderApp.Services
{
    public interface IBaseService<TEntity>
    {
        Task<Option<TEntity>> Save(TEntity entity);
        Task<ICollection<TEntity>> SaveAll(ICollection<TEntity> entities);
        Task<Option<TEntity>> Modify(TEntity entity);
        Task<Option<TEntity>> Update(TEntity entity);
        Task<Option<TEntity>> Get(TEntity example);
        Task<ICollection<TEntity>> GetAll();
    }
}
