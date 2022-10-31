using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Models.User;

namespace Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly TestContext _context;

        public UserRepository(TestContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Email == email);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}