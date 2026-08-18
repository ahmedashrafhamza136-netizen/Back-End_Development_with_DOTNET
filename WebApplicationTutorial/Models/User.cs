namespace WebApplicationTutorial.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public DateTime Created { get; set; } = DateTime.UtcNow;

        public List<string> Roles { get; set; } = new();
    }
}