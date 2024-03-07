using BrowserRentalCar.Domain.Dtos;
using MediatR;

namespace BrowserRentalCar.Application.Features.TravelHistories.Commands
{
    public record CreateTravelCommand(Guid VehicleId, Guid OriginId, Guid DestinationId, bool RouteComple, DateTime CreatedOn) : IRequest<VehicleVm>;
}