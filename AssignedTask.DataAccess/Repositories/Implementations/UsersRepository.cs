using AssignedTask.DataAccess.Models;
using AssignedTask.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace AssignedTask.DataAccess.Repositories.Implementations
{
    public class UsersRepository(AssignedTaskContext context) : IUsersRepository
    {
        private readonly AssignedTaskContext _context = context;

        public async Task<User?> GetUser(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(h => h.Email == email);
        }
    }
}