using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Dto.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Models.User;
using Repository;

namespace Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task RegisterUser(UserRegisterDto userDto)
        {
            if (!await CheckLoginExist(userDto.Email))
            {
                await _userRepository.AddUserAsync(_mapper.Map<UserRegisterDto, User>(userDto));
            }
        }

        public async Task<bool> LoginUser(UserLoginDto userDto, HttpContext context)
        {
            if (await CheckLoginExist(userDto.Email) && await CheckPasswordCorrect(userDto.Email, userDto.Password))
            {
                var claims = new List<Claim>
                {
                    new(ClaimTypes.Email, userDto.Email)
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var props = new AuthenticationProperties();
                context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();
                return true;
            }
            return false;
        }

        private async Task<bool> CheckLoginExist(string email)
        {
            var users = await _userRepository.GetAllUsersAsync();
            return users.Any(user => user.Email == email);
        }

        private async Task<bool> CheckPasswordCorrect(string email, string password)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            return user.Password == password;
        }
    }
}