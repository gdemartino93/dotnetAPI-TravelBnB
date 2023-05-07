using System.Text.RegularExpressions;
using TravelBnB_Utility;
using TravelBnB_Web.Models;
using TravelBnB_Web.Models.Dto;
using TravelBnB_Web.Services.IServices;

namespace TravelBnB_Web.Services
{
    public class AuthService : BaseService , IAuthService
    {
        private readonly IHttpClientFactory _client;
        private string url;
        public AuthService(IHttpClientFactory client, IConfiguration config) : base(client)
        {
            _client = client;
            url = config.GetValue<string>("ServiceUrls:TravelBnBAPI");
        }
        public Task<T> LoginAsync<T>(LoginRequestDTO loginRequestDTO)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticData.ApiType.POST,
                Data = loginRequestDTO,
                Url = url + "UserAuth/login"
            });
        }

        public Task<T> RegisterAsync<T>(RegisterRequestDTO registerRequestDTO)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticData.ApiType.POST,
                Data = registerRequestDTO,
                Url = url + "UserAuth/register"
            });
        }
    }
}
