
namespace Presistance.Data.Repositories
{
    public class UnitOfWork(ApplicationDbContext dbContext) : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext = dbContext;
        private readonly ConcurrentDictionary<string, object> _repos;
        public IGenericRepo<TEntity, Tkey> GetRepository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>

        => (IGenericRepo<TEntity,Tkey>) _repos.GetOrAdd(typeof(TEntity).Name, _ => new GenericRepo<TEntity, Tkey>(_dbContext));

   

            //new GenericRepo<TEntity, Tkey>(_dbContext);

        public async Task<int> SaveChangesAsync()=> await _dbContext.SaveChangesAsync();
    }
}
