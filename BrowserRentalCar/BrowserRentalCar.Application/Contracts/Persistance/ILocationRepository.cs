using BrowserRentalCar.Domain.Entities;

namespace BrowserRentalCar.Application.Contracts.Persistance
{
    public interface ILocationRepository : IAsyncRepository<Location>
    {
    }
}