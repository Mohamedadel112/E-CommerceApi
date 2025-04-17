using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IGenericRepo<TEntity,Tkey> where TEntity:BaseEntity<Tkey>
    {
        Task<TEntity?> GetByIdAsync(Tkey id);
        Task<IEnumerable<TEntity>> GetAllAsync(bool AsNoTracking=false);
        Task AddAsync(TEntity entity);
        void UpdateAsync(TEntity entity);
        void DeleteAsync(TEntity entity);
        Task<TEntity?> GetByIdAsync(Specification<TEntity> specification);
        Task<IEnumerable<TEntity>> GetAllAsync(Specification<TEntity> specifications);

    }
    
}
