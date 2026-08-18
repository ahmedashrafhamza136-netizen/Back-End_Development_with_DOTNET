namespace WebApplicationTutorial.DTOs
{
    public class RegisterRequest
    {
        public string Name { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
    public class LoginRequest
    {
        public string Name { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }


    public class AuthResponse
    {
        public string AccessToken { get; set; } = string.Empty;
    }
}
