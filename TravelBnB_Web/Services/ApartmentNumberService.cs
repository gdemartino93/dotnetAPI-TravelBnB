using TravelBnB_Web.Models;
using TravelBnB_Web.Services.IServices;

namespace TravelBnB_Web.Services
{
    public class ApartmentNumberService : BaseService, IApartmentNumberService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string aptUrl;

        public ApartmentNumberService(IHttpClientFactory httpClient, IConfiguration configuration) : base(httpClient)
        {
            _httpClientFactory = httpClient;
            aptUrl = configuration.GetValue<string>("ServiceUrls:TravelBnBAPI");
        }
        public Task<T> CreateAsync<T>(ApartmentNumberCreateDTO dto, string token)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = TravelBnB_Utility.StaticData.ApiType.POST,
                Data = dto,
                Url = aptUrl + "apartmentnumber",
                Token = token
            });
        }

        public Task<T> DeleteAsync<T>(int number, string token)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = TravelBnB_Utility.StaticData.ApiType.DELETE,
                Url = aptUrl + "apartmentnumber/" + number,
                Token = token
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = TravelBnB_Utility.StaticData.ApiType.GET,
                Url = aptUrl + "apartmentnumber",
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int number, string token)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = TravelBnB_Utility.StaticData.ApiType.GET,
                Url = aptUrl + "apartmentnumber/" + number,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(ApartmentNumberUpdateDTO dto, string token)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = TravelBnB_Utility.StaticData.ApiType.PUT,
                Url = aptUrl + "apartmentnumber/" + dto.AptNo,
                Data = dto,
                Token = token
            });
        }
       
    }
}
