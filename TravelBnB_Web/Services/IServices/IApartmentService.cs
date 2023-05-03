

namespace TravelBnB_Web.Services.IServices
{
    public interface IApartmentService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(Models.ApartmentCreateDTO dto);
        Task<T> UpdateAsync<T>(Models.ApartmentUpdateDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
