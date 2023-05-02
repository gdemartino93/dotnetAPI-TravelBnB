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
        public Task<T> CreateAsync<T>(ApartmentCreateDTO dto)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticData.ApiType.POST,
                Data = dto,
                Url = aptUrl + "apartment"
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticData.ApiType.DELETE,
                Url = aptUrl + "apartment/" + id
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticData.ApiType.GET,
                Url = aptUrl + "apartment"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticData.ApiType.GET,
                Url = aptUrl + "apartment/" + id
            });
        }

        public Task<T> UpdateAsync<T>(ApartmentUpdateDTO dto)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticData.ApiType.PUT,
                Data = dto,
                Url = aptUrl + "apartment/" + dto.Id
            });
        }
    }
}
