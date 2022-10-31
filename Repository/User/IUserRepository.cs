using System.Collections.Generic;
using System.Threading.Tasks;
using Models.User;

namespace Repository
{
    public interface IUserRepository
    {

        Task<User> GetUserByEmailAsync(string email);

        Task<List<User>> GetAllUsersAsync();

        Task AddUserAsync(User user);
    }
}