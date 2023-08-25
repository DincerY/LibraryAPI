using LibraryAPI.Application.Repositories;
using LibraryAPI.Domain.Entities.Common;
using LibraryAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;


namespace LibraryAPI.Persistence.Repositories
{
    public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : BaseEntity
    {
        readonly LibraryAPIDbContext _context;
        public ReadRepository(LibraryAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool withDeleted = false, bool enableTracking = true,
            CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = Query();
            if (!enableTracking) 
                queryable = queryable.AsNoTracking();
            if (include != null)
                queryable = include(queryable);
            if (withDeleted)
                queryable = queryable.IgnoreQueryFilters();

            return await queryable.FirstOrDefaultAsync(predicate, cancellationToken);

        }

        public IQueryable<TEntity> GetAll()
        {
            return Table.AsQueryable();
        }


        public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> method)
        {
            return Table.Where(method);
        }

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> method)
        {
            return await Table.FirstOrDefaultAsync(method);
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            return await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }

        public IQueryable<TEntity> Query() => _context.Set<TEntity>();
        



     

    }
}
