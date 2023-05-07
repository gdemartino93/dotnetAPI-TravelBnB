using TravelBnB_Web.Models.Dto;

namespace TravelBnB_Web.Services.IServices
{
    public interface IAuthService
    {
        Task<T> LoginAsync<T>(LoginRequestDTO loginRequestDTO);
        Task<T> RegisterAsync<T>(RegisterRequestDTO registerRequestDTO);
    }
}
