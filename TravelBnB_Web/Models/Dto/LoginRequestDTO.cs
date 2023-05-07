namespace TravelBnB_Web.Models.Dto
{
    public class LoginRequestDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string? Name { get; set; }
        public string Role { get; set; }
    }
}
