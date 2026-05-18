namespace Backapi.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Fname { get; set; } = string.Empty;

        public string Lname { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public int RoleId { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}