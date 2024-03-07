using AutoMapper;
using BrowserRentalCar.Application.Contracts.Persistance;
using BrowserRentalCar.Domain.Dtos;
using BrowserRentalCar.Domain.Entities;
using BrowserRentalCar.Infraestructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace BrowserRentalCar.Infraestructure.Repositories
{
    public class TravelHistoryRepository : RepositoryBase<TravelHistory>, ITravelHistoryRepository
    {
        private readonly IMapper _mapper;

        public TravelHistoryRepository(BrowserRentalCarDBContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public async Task<List<Vehicle>> SearchAvaibleVehicles(Guid originLocation, Guid destinationLocation)
        {
            return await  _context.Vehicles!
                .Include(v => v.TravelHistories)
                .Where(w => w.LocationId.Equals(originLocation) &&
                            w.Avaible.Equals(true)).ToListAsync();
        }
    }
}