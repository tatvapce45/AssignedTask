using AssignedTask.BusinessLogic.Dtos;
using AssignedTask.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssignedTask.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController(IHomeService homeService) : ControllerBase
    {
        private readonly IHomeService _homeService = homeService;
        
        [Authorize]
        [HttpPost("Products")]
        [ProducesResponseType(typeof(ProductsResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(object), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetProducts([FromBody] ProductsRequestDto productsRequestDto)
        {
            var result = await _homeService.GetProducts(productsRequestDto);
            if (result.Success)
            {
                return StatusCode(result.StatusCode, result.Data);
            }
            return StatusCode(result.StatusCode, new
            {
                result.Message,
                result.ValidationErrors,
                ExceptionMessage = result.Exception?.Message,
                ExceptionStackTrace = result.Exception?.StackTrace
            });
        }

    }
}