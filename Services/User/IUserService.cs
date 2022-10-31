using System.Threading.Tasks;
using Dto.User;
using Microsoft.AspNetCore.Http;

namespace Services
{
    public interface IUserService
    {
        Task RegisterUser(UserRegisterDto userDto);

        Task<bool> LoginUser(UserLoginDto userDto, HttpContext context);
    }
}