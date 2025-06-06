using AssignedTask.BusinessLogic.Dtos;
using AssignedTask.BusinessLogic.Results;
using AssignedTask.BusinessLogic.Services.Interfaces;
using AssignedTask.DataAccess.Models;
using AssignedTask.DataAccess.Repositories.Interfaces;

namespace AssignedTask.BusinessLogic.Services.Implementations
{
    public class HomeService(IProductsRepository productsRepository) : IHomeService
    {
        private readonly IProductsRepository _productsRepository = productsRepository;
        public async Task<ServiceResult<ProductsResponseDto>> GetProducts(ProductsRequestDto productsRequestDto)
        {
            try
            {
                List<Product> products = await _productsRepository.GetProducts(productsRequestDto.CategoryId, productsRequestDto.PageNumber, productsRequestDto.PageSize, productsRequestDto.SortBy, productsRequestDto.SortOrder, productsRequestDto.SearchTerm);
                int totalProducts = await _productsRepository.GetProductsCount(productsRequestDto.CategoryId, productsRequestDto.SearchTerm);
                if (products == null || products.Count == 0)
                {
                    return ServiceResult<ProductsResponseDto>.NotFound("No products found for the given criteria.");
                }
                ProductsResponseDto productsResponseDto = new()
                {
                    Products = products,
                    TotalProducts = totalProducts,
                    CurrentPage = productsRequestDto.PageNumber,
                    PageSize = productsRequestDto.PageSize,
                    SortBy = productsRequestDto.SortBy,
                    SortOrder = productsRequestDto.SortOrder,
                    TotalPages = (int)Math.Ceiling((double)totalProducts / productsRequestDto.PageSize)
                };

                return ServiceResult<ProductsResponseDto>.Ok(productsResponseDto);
            }
            catch (Exception ex)
            {
                return ServiceResult<ProductsResponseDto>.InternalError("An unexpected error occurred while fetching products.", ex);
            }
        }

    }
}