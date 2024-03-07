using AutoMapper;
using BrowserRentalCar.Application.Contracts.Persistance;
using BrowserRentalCar.Application.Exceptions;
using BrowserRentalCar.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BrowserRentalCar.Application.Features.Vehicles.Commands.UpdateVehicle
{
    public class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommand>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateVehicleCommandHandler> _logger;

        public UpdateVehicleCommandHandler(IVehicleRepository vehicleRepository, IMapper mapper, ILogger<UpdateVehicleCommandHandler> logger)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
        {
            var vehicleToUpdate = await _vehicleRepository.GetByIdAsync(request.Id);

            if (vehicleToUpdate == null)
            {
                _logger.LogError($"No se encontro el Vehiculo id {request.Id}");
                throw new NotFoundException(nameof(Vehicle), request.Id);
            }

            _mapper.Map(request, vehicleToUpdate, typeof(UpdateVehicleCommand), typeof(Vehicle));

            _logger.LogInformation($"La operacion fue exitosa Actualizando el Vehiculo {request.Id}");
            await _vehicleRepository.UpdateAsync(vehicleToUpdate);

            return Unit.Value;
        }

        Task IRequestHandler<UpdateVehicleCommand>.Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}