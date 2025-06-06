using AssignedTask.DataAccess.Models;

namespace AssignedTask.BusinessLogic.Dtos
{
    public class ProductsResponseDto
    {
        public List<Product> Products{get;set;}=[];

        public int PageSize{get;set;}

        public int PageNumber{get;set;}

        public int TotalPages{get;set;}

        public int TotalProducts{get;set;}

        public int CurrentPage{get;set;}

        public string SearchTerm{get;set;}=string.Empty;

        public string SortBy{get;set;}=string.Empty;

        public string SortOrder{get;set;}=string.Empty;
    }
}