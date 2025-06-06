namespace AssignedTask.BusinessLogic.Dtos
{
    public class ProductsRequestDto
    {
        public int CategoryId{get;set;}

        public int PageNumber{get;set;}=1;

        public int PageSize{get;set;}=5;

        public string SearchTerm{get;set;}=string.Empty;

        public string SortBy{get;set;}="name";

        public string SortOrder{get;set;}="asc";
    }
}