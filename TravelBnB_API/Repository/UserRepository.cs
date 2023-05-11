using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private string secretKey;
        private readonly IMapper _mapper;
        public UserRepository(ApplicationDbContext context, IConfiguration configuration, UserManager<ApplicationUser> userManager, IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
            //Console.WriteLine($"Secret Key: {secretKey}"); //debug
            _mapper = mapper;
            _roleManager = roleManager;
        }
        public bool IsUniqueUser(string username)
        {
            var user = _context.ApplicationUsers.FirstOrDefault(u => u.Name == username);
            if (user == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //metodo per la generazione del token
        private string GenerateJwtToken(ApplicationUser user, string secretKey)
        {
            var roles = _userManager.GetRolesAsync(user).Result;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Name, user.Id.ToString()),
            new Claim(ClaimTypes.Role, roles.FirstOrDefault())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        public async Task<UserDTO> Register(RegisterRequestDTO registerRequestDTO)
        {
            ApplicationUser newUser = new()
            {
                UserName = registerRequestDTO.Username,
                Name = registerRequestDTO.Name,
                Lastname = registerRequestDTO.Lastname,
                Email = registerRequestDTO.Username,
            };
            try
            {
                var createUser = await _userManager.CreateAsync(newUser, registerRequestDTO.Password);
                if (createUser.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync("admin").GetAwaiter().GetResult())
                    {
                        await _roleManager.CreateAsync(new IdentityRole { Name = "admin" });
                        await _roleManager.CreateAsync(new IdentityRole { Name = "user" });
                    }
                    await _userManager.AddToRoleAsync(newUser, "admin");
                    var userReturn = _context.ApplicationUsers.FirstOrDefault(u => u.UserName == registerRequestDTO.Username);

                    return _mapper.Map<UserDTO>(userReturn);
                }
            }
            catch (Exception)
            {
                 
            }
            return new UserDTO();
        }



        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = _context.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDTO.Username.ToLower());

            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDTO.Password);

            if (user == null || isValid == false)
            {
                return new LoginResponseDTO()
                {
                    Token = "",
                    User = null
                };
            }

            var token =  GenerateJwtToken(user, secretKey);
            var roles = await _userManager.GetRolesAsync(user);

            var loginResponseDTO = new LoginResponseDTO()
            {
                Token = token,
                User = _mapper.Map<UserDTO>(user),
            };

            return loginResponseDTO;
        }








    }
}
