using AutoMapper;
using BrowserRentalCar.Application.Contracts.Persistance;
using BrowserRentalCar.Application.Exceptions;
using BrowserRentalCar.Application.Features.TravelHistories.Query;
using BrowserRentalCar.Domain.Dtos;
using BrowserRentalCar.Domain.Entities;
using MediatR;

namespace BrowserRentalCar.Application.Features.Locations.TravelHistories.Query
{
    public class GetAvaibleVehiclesQueryHandler : IRequestHandler<GetAvaibleVehiclesQuery, List<VehicleVm>>
    {
        private readonly ITravelHistoryRepository _vehicleHistoryRepository;
        private readonly IMapper _mapper;

        public GetAvaibleVehiclesQueryHandler(ITravelHistoryRepository vehicleHistoryRepository, IMapper mapper)
        {
            _vehicleHistoryRepository = vehicleHistoryRepository;
            _mapper = mapper;
        }

        public async Task<List<VehicleVm>> Handle(GetAvaibleVehiclesQuery request, CancellationToken cancellationToken)
        {
            var avaibleVehicles = await _vehicleHistoryRepository.SearchAvaibleVehicles(request.originLocation, request.destinationLocation);

            if(avaibleVehicles == null || avaibleVehicles.Count==0) throw new NotFoundException(nameof(Vehicle), "Vehiculo");

            return _mapper.Map<List<VehicleVm>>(avaibleVehicles);
        }
    }
}