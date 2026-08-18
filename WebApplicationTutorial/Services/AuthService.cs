using Microsoft.AspNetCore.Identity.Data;
using WebApplicationTutorial.DTOs;
using WebApplicationTutorial.Models;
using WebApplicationTutorial.Security;
using RegisterRequest = WebApplicationTutorial.DTOs.RegisterRequest;

namespace WebApplicationTutorial.Interfaces
{
    public class AuthService
    {
        private readonly TokenService _tokenService;

        private static readonly List<User> Users = new();

        public AuthService(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public AuthResponse Register(RegisterRequest  request)
        {
            if (Users.Any(x => x.Name == request.Name))
            {
                throw new Exception("User already exists");
            }

            var user = new User
            {
                Id = Users.Count + 1,
                Name = request.Name,
                Password = request.Password,
                Created = DateTime.UtcNow,
                Roles = new List<string> { "User" }
            };

            Users.Add(user);

            var token = _tokenService.GenerateToken(
                user.Id.ToString(),
                user.Name,
                user.Roles
            );

            return new AuthResponse
            {
                AccessToken = token
            };
        }

        public AuthResponse Login(DTOs.LoginRequest request)
        {
            var user = Users.FirstOrDefault(x =>
                x.Name == request.Name &&
                x.Password == request.Password);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid username or password");
            }

            var token = _tokenService.GenerateToken(
                user.Id.ToString(),
                user.Name,
                user.Roles
            );

            return new AuthResponse
            {
                AccessToken = token
            };
        }
    }
}
