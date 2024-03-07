using AutoMapper;
using BrowserRentalCar.Application.Contracts.Persistance;
using BrowserRentalCar.Application.Exceptions;
using BrowserRentalCar.Domain.Dtos;
using BrowserRentalCar.Domain.Entities;
using MediatR;

namespace BrowserRentalCar.Application.Features.Vehicles.Query
{
    public class GetVehicleByIdQueryHandler : IRequestHandler<GetVehicleByIdQuery, VehicleVm>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public GetVehicleByIdQueryHandler(IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }
        public async Task<VehicleVm> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(request.Id);

            if (vehicle == null) throw new NotFoundException(nameof(Vehicle), request.Id);

            return _mapper.Map<VehicleVm>(vehicle);
        }
    }
}