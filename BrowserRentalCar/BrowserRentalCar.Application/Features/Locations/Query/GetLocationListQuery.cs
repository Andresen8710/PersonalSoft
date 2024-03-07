using BrowserRentalCar.Domain.Dtos;
using MediatR;

namespace BrowserRentalCar.Application.Features.Locations.Query
{
    public record GetLocationListQuery : IRequest<List<LocationVm>>
    {
    }
}