using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplicationTutorial.Models;

namespace WebApplicationTutorial.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(string userId, string username, IEnumerable<string> roles);



    }
}
