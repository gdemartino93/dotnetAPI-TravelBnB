using TravelBnB_API.Models;

namespace TravelBnB_API.Repository.IRepository
{
    public interface IApartmentNumberRepository : IRepository<ApartmentNumber>
    {
        Task<ApartmentNumber> UpdateAsync(ApartmentNumber apartmentNumber);
    }
}
