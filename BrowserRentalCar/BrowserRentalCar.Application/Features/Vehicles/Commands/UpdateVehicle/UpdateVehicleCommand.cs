using MediatR;

namespace BrowserRentalCar.Application.Features.Vehicles.Commands.UpdateVehicle
{
    public record UpdateVehicleCommand(Guid Id, 
                                       string Description, 
                                       string Model, 
                                       string Plate, 
                                       string Brand, 
                                       bool Avaible, 
                                       DateTime CreationDate) : IRequest;
}