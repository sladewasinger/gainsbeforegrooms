using GBGApi.Models;
using GBGApi.Models.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GBGApi.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly PasswordHasher<User> _passwordHasher;

        public UserService(IConfiguration configuration)
        {
            _configuration = configuration;
            _passwordHasher = new PasswordHasher<User>();  // Initialize the built-in password hasher
        }

        public async Task<User> Register(UserRegistrationDto registrationDto)
        {
            // Create user instance
            var user = new User
            {
                Username = registrationDto.Username,
                Email = registrationDto.Email
            };

            // Hash password using the built-in PasswordHasher
            user.PasswordHash = _passwordHasher.HashPassword(user, registrationDto.Password);

            // Save user to DB (example with Entity Framework)
            // await _context.Users.AddAsync(user);
            // await _context.SaveChangesAsync();

            return user;
        }

        public async Task<string> Login(UserLoginDto loginDto)
        {
            // Query the database to get the user by username (or email)
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == loginDto.Username);

            if (user == null || !VerifyPasswordHash(loginDto.Password, user.PasswordHash))
                throw new UnauthorizedAccessException("Invalid username or password");

            return GenerateJwtToken(user);
        }

        public bool VerifyPasswordHash(string password, string passwordHash)
        {
            // Verify password using the built-in PasswordHasher
            var result = _passwordHasher.VerifyHashedPassword(null, passwordHash, password);
            return result == PasswordVerificationResult.Success;
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

