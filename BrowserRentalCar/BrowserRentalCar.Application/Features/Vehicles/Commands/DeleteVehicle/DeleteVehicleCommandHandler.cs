using AutoMapper;
using BrowserRentalCar.Application.Contracts.Persistance;
using BrowserRentalCar.Application.Exceptions;
using BrowserRentalCar.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserRentalCar.Application.Features.Vehicles.Commands.DeleteVehicle
{
    public class DeleteVehicleCommandHandler : IRequestHandler<DeleteVehicleCommand>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteVehicleCommandHandler> _logger;

        public DeleteVehicleCommandHandler(IVehicleRepository vehicleRepository, IMapper mapper, ILogger<DeleteVehicleCommandHandler> logger)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
        {
            var vehicleToDelete = await _vehicleRepository.GetByIdAsync(request.Id);

            if(vehicleToDelete == null) 
            {
                _logger.LogError($"{request.Id} Vehiculo no existe enel sistema");
                throw new NotFoundException(nameof(Vehicle), request.Id);
            }

            await _vehicleRepository.DeleteAsync(vehicleToDelete);

        }
    }
}
