using AssignedTask.DataAccess.Models;
using AssignedTask.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace AssignedTask.DataAccess.Repositories.Implementations
{
    public class ProductsRepository(AssignedTaskContext context):IProductsRepository
    {
        private readonly AssignedTaskContext _context=context;
        public async Task<List<Product>> GetProducts(int categoryId,int pageNumber,int pageSize,string sortBy,string sortOrder,string searchTerm)
        {
            var query = _context.Products.Where(p=>(string.IsNullOrEmpty(searchTerm) || p.Name.ToLower().Contains(searchTerm.ToLower()))&& p.CategoryId==categoryId);
            if(sortBy.Equals("name",StringComparison.OrdinalIgnoreCase))
            {
                query=sortOrder.Equals("asc")?query.OrderBy(p=>p.Name):query.OrderByDescending(p=>p.Name);
            }
            else if(sortBy.Equals("price",StringComparison.OrdinalIgnoreCase))
            {
                query = sortOrder.Equals("asc") ? query.OrderBy(p =>p.Price):query.OrderByDescending(p=>p.Price);
            }
            else if(sortBy.Equals("quantity",StringComparison.OrdinalIgnoreCase))
            {
                query = sortOrder.Equals("asc") ? query.OrderBy(p =>p.Quantity):query.OrderByDescending(p=>p.Quantity);
            }
            else
            {
                query = sortOrder.Equals("asc") ? query.OrderBy(p =>p.CategoryId):query.OrderByDescending(p=>p.CategoryId);
            }
            var products = await query.Skip((pageNumber-1)*pageSize).Take(pageSize).ToListAsync();
            return products;
        }

        public async Task<int> GetProductsCount(int categoryId,string searchTerm)
        {
            return await _context.Products.Where(p=>(string.IsNullOrEmpty(searchTerm) || p.Name.ToLower().Contains(searchTerm.ToLower()))&& p.CategoryId==categoryId).CountAsync();
        }
    }
}