using AutoMapper;
using BrowserRentalCar.Application.Contracts.Persistance;
using BrowserRentalCar.Domain.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserRentalCar.Application.Features.Locations.Query
{
    public class GetLocationListQueryHandler : IRequestHandler<GetLocationListQuery, List<LocationVm>>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public GetLocationListQueryHandler(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public async Task<List<LocationVm>> Handle(GetLocationListQuery request, CancellationToken cancellationToken)
        {
            var locationList = await _locationRepository.GetAllAsync();
            return _mapper.Map<List<LocationVm>>(locationList);
        }
    }
}
