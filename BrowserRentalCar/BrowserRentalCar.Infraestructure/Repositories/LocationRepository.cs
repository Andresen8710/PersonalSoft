using BrowserRentalCar.Application.Contracts.Persistance;
using BrowserRentalCar.Domain.Entities;
using BrowserRentalCar.Infraestructure.Persistance;

namespace BrowserRentalCar.Infraestructure.Repositories
{
    public class LocationRepository : RepositoryBase<Location>, ILocationRepository
    {
        public LocationRepository(BrowserRentalCarDBContext dbContext) : base(dbContext) { }
    }
}