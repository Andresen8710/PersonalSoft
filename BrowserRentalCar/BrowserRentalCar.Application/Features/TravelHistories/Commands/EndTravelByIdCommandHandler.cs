using AutoMapper;
using BrowserRentalCar.Application.Contracts.Persistance;
using BrowserRentalCar.Application.Exceptions;
using BrowserRentalCar.Domain.Dtos;
using BrowserRentalCar.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BrowserRentalCar.Application.Features.TravelHistories.Commands
{
    public class EndTravelByIdCommandHandler : IRequestHandler<EndTravelByIdCommand, TravelHistoryVm>
    {
        private readonly ITravelHistoryRepository _travelHistoryRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<EndTravelByIdCommandHandler> _logger;

        public EndTravelByIdCommandHandler(ITravelHistoryRepository travelHistoryRepository, IVehicleRepository vehicleRepository, IMapper mapper, ILogger<EndTravelByIdCommandHandler> logger)
        {
            _travelHistoryRepository = travelHistoryRepository;
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<TravelHistoryVm> Handle(EndTravelByIdCommand request, CancellationToken cancellationToken)
        {
            var travelHistoryToUpdate = await _travelHistoryRepository.GetByIdAsync(request.TravelHistoryId);

            if (travelHistoryToUpdate == null) throw new NotFoundException(nameof(TravelHistory), request.TravelHistoryId);

            travelHistoryToUpdate.RouteComple = true;

            await _travelHistoryRepository.UpdateAsync(travelHistoryToUpdate);

            //valido el vehiculo a Actualizar
            var vehicleToUpdate = await _vehicleRepository.GetByIdAsync(travelHistoryToUpdate.VehicleId);

            //actualizo el campo Avaible y la localizacion
            vehicleToUpdate.Avaible = true;
            vehicleToUpdate.LocationId = travelHistoryToUpdate.DestinationId;

            //Actualizo el vehiculo
            await _vehicleRepository.UpdateAsync(vehicleToUpdate);

            var travelHistoryVm = _mapper.Map<TravelHistoryVm>(travelHistoryToUpdate);

            return travelHistoryVm;
        }
    }
}