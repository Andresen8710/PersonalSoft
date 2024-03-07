using AutoMapper;
using BrowserRentalCar.Application.Contracts.Persistance;
using BrowserRentalCar.Application.Exceptions;
using BrowserRentalCar.Domain.Dtos;
using BrowserRentalCar.Domain.Entities;
using MediatR;

namespace BrowserRentalCar.Application.Features.Locations.Query
{
    public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, LocationVm>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public GetLocationByIdQueryHandler(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }
        public async Task<LocationVm> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var location = await _locationRepository.GetByIdAsync(request.Id);

            if(location == null) throw new NotFoundException(nameof(Location), request.Id);

            return _mapper.Map<LocationVm>(location);
        }
    }
}