using AssignedTask.DataAccess.Models;

namespace AssignedTask.DataAccess.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        Task<User?> GetUser(string email);
    }
}