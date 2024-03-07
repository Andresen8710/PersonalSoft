using MediatR;

namespace BrowserRentalCar.Application.Features.Vehicles.Commands.CreateVehicle
{
    public record CreateVehicleCommand(string Description, string Model, string Plate,string Brand, bool Avaible,Guid? LocationId) : IRequest<Guid>;

}