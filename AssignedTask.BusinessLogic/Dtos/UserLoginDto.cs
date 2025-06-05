using System.Text.Json.Serialization;

namespace AssignedTask.BusinessLogic.Dtos
{
    public class UserLoginDto
    {
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public bool RememberMe { get; set; }=false;

        public string JwtToken{get;set;}=string.Empty;
    }
}