using Microsoft.AspNetCore.Identity;

namespace TravelBnB_API.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
    }
}
