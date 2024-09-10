using GBGApi.Models;
using GBGApi.Models.DTO;

namespace GBGApi.Services
{
    public interface IUserService
    {
        Task<string> Login(UserLoginDto loginDto);
        Task<User> Register(UserRegistrationDto registrationDto);
        bool VerifyPasswordHash(string password, string passwordHash);
    }
}