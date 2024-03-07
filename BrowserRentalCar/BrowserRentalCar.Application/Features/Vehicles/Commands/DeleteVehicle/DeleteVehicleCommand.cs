using MediatR;

namespace BrowserRentalCar.Application.Features.Vehicles.Commands.DeleteVehicle
{
    public record DeleteVehicleCommand(Guid Id) : IRequest;
}