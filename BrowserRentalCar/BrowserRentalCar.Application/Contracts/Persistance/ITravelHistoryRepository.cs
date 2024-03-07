using BrowserRentalCar.Domain.Dtos;
using BrowserRentalCar.Domain.Entities;

namespace BrowserRentalCar.Application.Contracts.Persistance
{
    public interface ITravelHistoryRepository : IAsyncRepository<TravelHistory>
    {
        Task<List<Vehicle>> SearchAvaibleVehicles(Guid originLocation, Guid destinationLocation);
    }
}