using BrowserRentalCar.Domain.Dtos;
using MediatR;

namespace BrowserRentalCar.Application.Features.Locations.Query
{
    public record GetLocationByIdQuery(Guid Id) : IRequest<LocationVm>
    {
    }
}