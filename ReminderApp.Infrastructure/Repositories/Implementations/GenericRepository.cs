using Microsoft.EntityFrameworkCore;
using ReminderApp.Application.Repositories;
using ReminderApp.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApp.Infrastructure.Repositories.Implementations
{
   
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ReminderAppDbContext _context;
        protected DbSet<T> _dbSet;
        public GenericRepository(ReminderAppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();

        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
     
        public async Task<T?> GetByIdAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity;
        }

        public async Task<bool> IsExistsAsync(Guid id)
        {
            return (await _dbSet.FindAsync(id)) != null;
        }

#warning refactor these two
        public Task UpdateAsync(T entity)
        {
            return Task.FromResult(_dbSet.Update(entity));
        }

        public async Task DeleteAsync(T entity)
        {
           _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
    }
}
