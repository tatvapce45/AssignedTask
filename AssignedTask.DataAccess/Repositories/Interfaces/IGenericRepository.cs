using AssignedTask.DataAccess.Results;

namespace AssignedTask.DataAccess.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<RepositoryResult<T>> AddAsync(T entity);
    }
}