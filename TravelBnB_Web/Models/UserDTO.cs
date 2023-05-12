namespace TravelBnB_Web.Models
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
