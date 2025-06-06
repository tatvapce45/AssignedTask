using AssignedTask.BusinessLogic.Dtos;
using AssignedTask.BusinessLogic.Results;

namespace AssignedTask.BusinessLogic.Services.Interfaces
{
    public interface IHomeService
    {
        Task<ServiceResult<ProductsResponseDto>> GetProducts(ProductsRequestDto productsRequestDto);
    }
}