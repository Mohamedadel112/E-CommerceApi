using Domain.Contracts;

namespace Presistance.Data.Repositories
{
    public class GenericRepo<TEntity, Tkey> : IGenericRepo<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        private readonly ApplicationDbContext _dbcontext;
        public GenericRepo(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }


        public async Task AddAsync(TEntity entity)=> await _dbcontext.Set<TEntity>().AddAsync(entity);  
     

        public void DeleteAsync(TEntity entity) => _dbcontext.Set<TEntity>().Remove(entity);

        public async Task<IEnumerable<TEntity>> GetAllAsync(bool AsNoTracking) => 
            AsNoTracking ? await _dbcontext.Set<TEntity>().AsNoTracking().ToListAsync() 
                         : await _dbcontext.Set<TEntity>().ToListAsync();

        public async Task<TEntity?> GetByIdAsync(Tkey id) => await _dbcontext.Set<TEntity>().FindAsync(id);


        public void UpdateAsync(TEntity entity)=> _dbcontext.Set<TEntity>().Update(entity); 
 
        public async Task<TEntity?> GetByIdAsync(Specification<TEntity> specification)
        => await ApplySpecification(specification).FirstOrDefaultAsync();
        
        public async Task<IEnumerable<TEntity>> GetAllAsync(Specification<TEntity> specifications)        
            => await ApplySpecification(specifications).ToListAsync();

        

        private IQueryable<TEntity>ApplySpecification(Specification<TEntity> specification)
        
        => SpecificationEvaluator.GetQuery<TEntity>(_dbcontext.Set<TEntity>(),specification);
        

}
}
