using TravelBnB_API.Models;
using TravelBnB_API.Models.Dto;

namespace TravelBnB_API.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<LocalUser> Register(RegisterRequestDTO registerRequestDTO);
    }
}
