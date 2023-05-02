using TravelBnB_Web.Models;

namespace TravelBnB_Web.Services.IServices
{
    public interface IBaseService
    {
        public APIResponse ResponseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
