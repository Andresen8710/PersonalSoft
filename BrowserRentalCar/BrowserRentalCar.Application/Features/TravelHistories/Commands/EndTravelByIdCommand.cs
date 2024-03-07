using BrowserRentalCar.Domain.Dtos;
using MediatR;

namespace BrowserRentalCar.Application.Features.TravelHistories.Commands
{
    public record EndTravelByIdCommand(Guid TravelHistoryId) : IRequest<TravelHistoryVm>
    {
    }
}