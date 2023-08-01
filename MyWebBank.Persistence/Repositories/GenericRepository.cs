using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyWebBank.Application.Exceptions;
using MyWebBank.Application.Interfaces;
using MyWebBank.Domain.Entities;
using System.Security.Claims;

namespace MyWebBank.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _dbContext;
        internal DbSet<T> _dbSet;
        private readonly IHttpContextAccessor _contextAccessor;

        public GenericRepository(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
            _contextAccessor = httpContextAccessor;
        }

        public Guid UserId
        {
            get
            {
                var userIdStr = _contextAccessor.HttpContext?.User?.FindFirstValue("uid");
                if (Guid.TryParse(userIdStr, out var userId))
                {
                    return userId;
                }
                else
                {
                    return Guid.Empty;
                }
            }
        }
        public Guid AccountId
        {
            get
            {
                var accountIdStr = _contextAccessor.HttpContext?.User?.FindFirstValue("AccountId");
                if (Guid.TryParse(accountIdStr, out var accountId))
                {
                    return accountId;
                }
                else
                {
                    return Guid.Empty;
                }
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entities = await _dbSet.AsNoTracking().ToListAsync();

            return entities;
        }

        public async Task<T> GetByIdAsync(Guid entityId)
        {
            var entity = await _dbSet.AsNoTracking().FirstOrDefaultAsync(temp => temp.Id == entityId);

            if (entity == null)
            {
                throw new EntityNotFoundException("Entity not found");
            }

            return entity;
        }

        public async Task<T> CreateAsync(T entity)
        {
            var addedEntity = await _dbSet.AddAsync(entity);
            var result = await _dbContext.SaveChangesAsync();
            if (result > 0)
            {
                return addedEntity.Entity;
            }
            else
            {
                throw new BadRequestException("Entity not added");
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(a => a.Id == id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Entity not found");
            }
            else
            {
                _dbSet.Remove(entity);
                var result = await _dbContext.SaveChangesAsync();
                return result > 0;
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            var result = await _dbContext.SaveChangesAsync();
            var updatedEntity = await _dbSet.FirstOrDefaultAsync(e => e.Id == entity.Id);
            if (updatedEntity != null && result > 0)
            {
                return updatedEntity;
            }
            else
            {
                throw new EntityNotFoundException("Updated entity not found");
            }
        }
    }
}
