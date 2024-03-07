using AutoMapper;
using BrowserRentalCar.Application.Contracts.Persistance;
using BrowserRentalCar.Application.Exceptions;
using BrowserRentalCar.Domain.Dtos;
using BrowserRentalCar.Domain.Entities;
using MediatR;

namespace BrowserRentalCar.Application.Features.Vehicles.Query
{
    public class GetVehicleListHandler : IRequestHandler<GetVehicleListQuery, List<VehicleVm>>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public GetVehicleListHandler(IMapper mapper, IVehicleRepository vehicleRepository)
        {
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
        }

        public async Task<List<VehicleVm>> Handle(GetVehicleListQuery request, CancellationToken cancellationToken)
        {
            var vehicleList = await _vehicleRepository.GetAllAsync();

            if(vehicleList == null|| vehicleList.Count==0) throw new NotFoundException(nameof(Vehicle), "registro");

            return _mapper.Map<List<VehicleVm>>(vehicleList);
        }
    }
}