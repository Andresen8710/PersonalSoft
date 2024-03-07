using AutoMapper;
using BrowserRentalCar.Application.Contracts.Persistance;
using BrowserRentalCar.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BrowserRentalCar.Application.Features.Locations.Commands.CreateLocation
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, Guid>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateLocationCommandHandler> _logger;

        public CreateLocationCommandHandler(ILocationRepository locationRepsitory, IMapper mapper, ILogger<CreateLocationCommandHandler> logger)
        {
            _locationRepository = locationRepsitory;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var locationEntity = _mapper.Map<Location>(request);
            var newLocation = await _locationRepository.AddAsync(locationEntity);

            _logger.LogInformation($"Location {newLocation.Id} Was Created Succesfuly.");

            return newLocation.Id;
        }
    }
}