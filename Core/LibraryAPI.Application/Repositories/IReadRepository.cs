using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore.Query;

namespace LibraryAPI.Application.Repositories
{
    public interface IReadRepository<TEntity> : IRepository<TEntity>,IQuery<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetAsync(
            Expression<Func<TEntity,bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include=null,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default);
                
                


        IQueryable<TEntity> GetAll(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);
        IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> method);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> method);
        Task<TEntity> GetByIdAsync(string id,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);
        

    }
}
