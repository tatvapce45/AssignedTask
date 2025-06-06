using AssignedTask.DataAccess.Models;

namespace AssignedTask.DataAccess.Repositories.Interfaces
{
    public interface IProductsRepository
    {
        Task<List<Product>> GetProducts(int categoryId,int pageNumber,int pageSize,string sortBy,string sortOrder,string searchTerm);

        Task<int> GetProductsCount(int categoryId,string searchTerm);
    }
}