using TravelBnB_Utility;
using TravelBnB_Web.Models;
using TravelBnB_Web.Services.IServices;

namespace TravelBnB_Web.Services
{
    public class ApartmentService : BaseService , IApartmentService 
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string aptUrl;
        public ApartmentService(IHttpClientFactory httpClientFactory, IConfiguration configuration) :base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            aptUrl = configuration.GetValue<string>("ServiceUrls:TravelBnBAPI"); 
        }
        public Task<T> CreateAsync<T>(ApartmentCreateDTO dto, string token)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticData.ApiType.POST,
                Data = dto,
                Url = aptUrl + "apartment",
                Token = token
            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticData.ApiType.DELETE,
                Url = aptUrl + "apartment/" + id,
                Token = token
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticData.ApiType.GET,
                Url = aptUrl + "apartment",
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticData.ApiType.GET,
                Url = $"{aptUrl}apartment/{id}",
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(ApartmentUpdateDTO dto, string token)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticData.ApiType.PUT,
                Data = dto,
                Url = aptUrl + "apartment/" + dto.Id,
                Token = token
            });
        }
    }
}
