using BrowserRentalCar.Domain.Dtos;
using MediatR;

namespace BrowserRentalCar.Application.Features.Vehicles.Query
{
    public record GetVehicleListQuery() : IRequest<List<VehicleVm>>;
    
}