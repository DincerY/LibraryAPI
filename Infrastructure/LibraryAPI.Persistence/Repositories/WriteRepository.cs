using LibraryAPI.Application.Repositories;
using LibraryAPI.Domain.Entities.Common;
using LibraryAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LibraryAPI.Persistence.Repositories
{
    public class WriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : BaseEntity
    {
        readonly LibraryAPIDbContext _context;
        public WriteRepository(LibraryAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> Table => _context.Set<TEntity>();
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            EntityEntry entry =await Table.AddAsync(entity);
            TEntity addedEntity = (TEntity)entry.Entity;
            await _context.SaveChangesAsync();
            return addedEntity;
        }

        public async Task<bool> AddRangeAsync(List<TEntity> datas)
        {
           await Table.AddRangeAsync(datas);
           return true;
        }

        public async Task<TEntity> Remove(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return entity;
        }

        public bool RemoveRange(List<TEntity> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }

        public async Task<bool> RemoveByIdAsync(string id)
        {
            TEntity? model = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
            EntityEntry entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public TEntity Update(TEntity model)
        {
            EntityEntry entityEntry = Table.Update(model);
            if (entityEntry.State == EntityState.Modified)
            {
                return model;
            }
            else
            {
                return null;
            }
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
