using System.Linq.Expressions;
using TravelBnB_API.Models;

namespace TravelBnB_API.Repository.IRepository
{
    public interface IApartmentRepository : IRepository<Apartment>
    {
        Task<Apartment> UpdateAsync(Apartment apartment);
    }
}
