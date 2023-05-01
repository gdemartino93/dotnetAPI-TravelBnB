using TravelBnB_API.Data;
using TravelBnB_API.Models;
using TravelBnB_API.Repository.IRepository;

namespace TravelBnB_API.Repository
{
    public class ApartmentNumberRepository : Repository<ApartmentNumber>, IApartmentNumberRepository
    {
        private readonly ApplicationDbContext _db;
        public ApartmentNumberRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<ApartmentNumber> UpdateAsync(ApartmentNumber apartmentNumber)
        {
            apartmentNumber.UpdatedDate = DateTime.Now;
            _db.ApartmentNumbers.Update(apartmentNumber);
            await _db.SaveChangesAsync();
            return apartmentNumber;
        }
    }

}
