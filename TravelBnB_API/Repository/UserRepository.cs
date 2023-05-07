using Microsoft.AspNetCore.DataProtection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TravelBnB_API.Data;
using TravelBnB_API.Models;
using TravelBnB_API.Models.Dto;
using TravelBnB_API.Repository.IRepository;

namespace TravelBnB_API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private string secretKey;
        public UserRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
            Console.WriteLine($"Secret Key: {secretKey}");
        }
        public bool IsUniqueUser(string username)
        {
            var user = _context.LocalUsers.FirstOrDefault(x => x.Username == username);
            if (user == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = _context.LocalUsers.FirstOrDefault(u =>
            u.Username.ToLower() == loginRequestDTO.Username.ToLower() &&
            u.Password == loginRequestDTO.Password);
            if (user == null)
            {
                new LoginResponseDTO()
                {
                    User = null,
                    Token = "",
                };
            }
            //generiamo il token
            var token = GenerateJwtToken(user);
            var response = new LoginResponseDTO
            {
                Token = token,
                User = user,
            };
            return Task.FromResult(response);

        }

        public async Task<LocalUser> Register(RegisterRequestDTO registerRequestDTO)
        {
            LocalUser newUser = new LocalUser()
            {
                Username = registerRequestDTO.Username,
                Name = registerRequestDTO.Name,
                Password = registerRequestDTO.Password,
                Role = registerRequestDTO.Role,
            };
            _context.LocalUsers.Add(newUser);
            _context.SaveChanges();
            newUser.Password = ""; //azzeriamo il campo password dopo averlo salvato nel db per fare in modo che non torna la password come risposta dall api
            return newUser;
        }
        //metodo per la generazione del Jwt Token e definizione del contenuto
        private string GenerateJwtToken(LocalUser user)
        {
            if (user == null)
            {
                return string.Empty;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
