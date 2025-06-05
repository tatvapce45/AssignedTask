using AssignedTask.BusinessLogic.Dtos;
using AssignedTask.BusinessLogic.Results;

namespace AssignedTask.BusinessLogic.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<ServiceResult<UserRegistrationDto>> RegisterUser(UserRegistrationDto userRegistrationDto);

        Task<ServiceResult<UserLoginDto>> Login(UserLoginDto userLoginDto);
    }
}