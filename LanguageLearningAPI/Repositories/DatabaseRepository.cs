using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LanguageLearningAPI.Models;

namespace LanguageLearningAPI.Repositories
{
    public class DatabaseRepository
    {
        private readonly ApplicationDbContext _context;

        public DatabaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create
        public async Task AddEntityAsync<TEntity>(TEntity entity) where TEntity : class
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        // Read
        public async Task<TEntity> GetEntityByIdAsync<TEntity>(int id) where TEntity : class
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetAllEntitiesAsync<TEntity>() where TEntity : class
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        // Update
        public async Task UpdateEntityAsync<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        // Delete
        public async Task DeleteEntityAsync<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
