//using Microsoft.AspNetCore.Mvc;
//using WebApplicationTutorial.DTOs;
//using WebApplicationTutorial.Interfaces;
//using WebApplicationTutorial.Security;

//namespace WebApplicationTutorial.Controllers
//{
//    [ApiController]
//    [Route("api/")]
//    public class AuthController : ControllerBase
//    {
//        private readonly AuthService _authService;

//        public AuthController(AuthService authService)
//        {
//            _authService = authService;
//        }

//        [HttpPost("register")]
//        public IActionResult Register(RegisterRequest request)
//        {
//            return Ok(_authService.Register(request));
//        }

//        [HttpPost("login")]
//        public IActionResult Login(LoginRequest request)
//        {
//            return Ok(_authService.Login(request));
//        }
//    }

//    //public record LoginRequest(string Username, string Password);
//}
