using BrowserRentalCar.Domain.Dtos;
using MediatR;

namespace BrowserRentalCar.Application.Features.Vehicles.Query
{
    public record GetVehicleByIdQuery(Guid Id) : IRequest<VehicleVm>;
}