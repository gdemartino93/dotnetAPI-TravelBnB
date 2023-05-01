using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using TravelBnB_API.Data;
using TravelBnB_API.Models;
using TravelBnB_API.Repository.IRepository;

namespace TravelBnB_API.Repository
{
    public class ApartmentRepository : Repository<Apartment>, IApartmentRepository
    {
        private readonly ApplicationDbContext _db;
        public ApartmentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Apartment> UpdateAsync(Apartment apartment)
        {
            apartment.UpdatedDate = DateTime.Now;
            _db.Apartments.Update(apartment);
            await _db.SaveChangesAsync();
            return apartment;
        }
    }
}
