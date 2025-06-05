using AssignedTask.DataAccess.Models;
using AssignedTask.DataAccess.Repositories.Interfaces;
using AssignedTask.DataAccess.Results;
using Microsoft.EntityFrameworkCore;
namespace AssignedTask.DataAccess.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AssignedTaskContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AssignedTaskContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<RepositoryResult<T>> AddAsync(T entity)
        {
            var result = new RepositoryResult<T>();
            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                result.Success = true;
                result.Data = entity;
            }
            catch (DbUpdateException ex)
            {
                result.Success = false;
                result.ErrorMessage = $"Database update error: {ex.Message}";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = $"Unexpected error: {ex.Message}";
            }
            return result;
        }
    }
}