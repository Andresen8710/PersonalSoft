using AutoMapper;
using BrowserRentalCar.Application.Contracts.Persistance;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BrowserRentalCar.Application.Features.Vehicles.Commands.CreateVehicle
{
    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, Guid>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateVehicleCommandHandler> _logger;

        public CreateVehicleCommandHandler(IVehicleRepository vehicleRepository, IMapper mapper, ILogger<CreateVehicleCommandHandler> logger)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            var vehicleEntity = _mapper.Map<Domain.Entities.Vehicle>(request);

            //if (request.LocationId.HasValue)
            //{
            //    vehicleEntity.LocationId = request.LocationId;
            //}

            var newVehicle = await _vehicleRepository.AddAsync(vehicleEntity);

            _logger.LogInformation($"Vechile {newVehicle.Id} Was Created Succesfuly.");

            return newVehicle.Id;
        }
    }
}