using AutoMapper;
using BrowserRentalCar.Application.Contracts.Persistance;
using BrowserRentalCar.Application.Exceptions;
using BrowserRentalCar.Domain.Dtos;
using BrowserRentalCar.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BrowserRentalCar.Application.Features.TravelHistories.Commands
{
    public class CreateTravelCommandHandler : IRequestHandler<CreateTravelCommand, VehicleVm>
    {
        private readonly ITravelHistoryRepository _travelHistoryRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateTravelCommandHandler> _logger;

        public CreateTravelCommandHandler(IMapper mapper, ITravelHistoryRepository travelHistoryRepository, IVehicleRepository vehicleRepository, ILogger<CreateTravelCommandHandler> logger)
        {
            _vehicleRepository = vehicleRepository;
            _travelHistoryRepository = travelHistoryRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<VehicleVm> Handle(CreateTravelCommand request, CancellationToken cancellationToken)
        {
            VehicleVm vehicleVm = new VehicleVm();

            var vehicleHistoryEntity = _mapper.Map<TravelHistory>(request);

            var newVehiculeHistory = await _travelHistoryRepository.AddAsync(vehicleHistoryEntity);

            if (newVehiculeHistory != null)
            {
                var vehicleEntity = await _vehicleRepository.GetByIdAsync(newVehiculeHistory.VehicleId);

                if (vehicleEntity == null) throw new NotFoundException(nameof(Vehicle), newVehiculeHistory.VehicleId);

                vehicleEntity.Avaible = false;

                await _vehicleRepository.UpdateAsync(vehicleEntity);

                vehicleVm = _mapper.Map<VehicleVm>(vehicleEntity);

                vehicleVm.TravleId = newVehiculeHistory.Id.ToString();
            }
            else
            {
                throw new ApplicationException("No se logro insertar el registro.");
            }

            return vehicleVm;
        }
    }
}