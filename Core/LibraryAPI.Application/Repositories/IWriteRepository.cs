using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAPI.Domain.Entities.Common;

namespace LibraryAPI.Application.Repositories
{
    public interface IWriteRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<bool> AddRangeAsync(List<TEntity> datas);
        Task<TEntity> Remove(TEntity entity);
        bool RemoveRange(List<TEntity> datas);
        Task<bool> RemoveByIdAsync(string id);
        TEntity Update(TEntity model);
        Task<int> SaveAsync();
    }
}
