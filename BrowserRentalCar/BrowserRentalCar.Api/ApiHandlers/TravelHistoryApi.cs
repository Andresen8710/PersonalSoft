using BrowserRentalCar.Application.Features.TravelHistories.Commands;
using BrowserRentalCar.Application.Features.TravelHistories.Query;
using BrowserRentalCar.Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Routing;

namespace BrowserRentalCar.Api.ApiHandlers
{
    public static class TravelHistoryApi
    {
        public static RouteGroupBuilder MapTravelHistory(this IEndpointRouteBuilder routeBuilder)
        {
            routeBuilder.MapGet("/getAvaibleVehicle", async (IMediator mediator, Guid originLocation, Guid destinationLocation) =>
            {
                return Results.Ok(await mediator.Send(new GetAvaibleVehiclesQuery(originLocation, destinationLocation)));
            }).Produces(StatusCodes.Status200OK, typeof(VehicleVm));

            routeBuilder.MapPost("/", async (IMediator mediator, CreateTravelCommand createTravelCommand) =>
            {
                var user = await mediator.Send(createTravelCommand);

                return Results.Created(new Uri($"/api/TravelHistory/", UriKind.Relative), user);
            }).Produces(statusCode: StatusCodes.Status201Created);

            routeBuilder.MapPut("/endServiceById", async (IMediator mediator, Guid travelVehicleId) =>
            {
                return Results.Ok(await mediator.Send(new EndTravelByIdCommand(travelVehicleId)));
            })
        .Produces(StatusCodes.Status200OK, typeof(TravelHistoryVm));

            return (RouteGroupBuilder)routeBuilder;
        }
    }
}