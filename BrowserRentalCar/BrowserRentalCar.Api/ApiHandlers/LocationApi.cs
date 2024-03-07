using BrowserRentalCar.Application.Features.Locations.Commands.CreateLocation;
using BrowserRentalCar.Application.Features.Locations.Query;
using BrowserRentalCar.Application.Features.Vehicles.Commands.CreateVehicle;
using BrowserRentalCar.Application.Features.Vehicles.Query;
using BrowserRentalCar.Domain.Dtos;
using MediatR;

namespace BrowserRentalCar.Api.ApiHandlers
{
    public static class LocationApi
    {
        public static  RouteGroupBuilder MapLocation(this IEndpointRouteBuilder routeBuilder) 
        {
            routeBuilder.MapGet("/getById", async (IMediator mediator, Guid Id) =>
            {
                return Results.Ok(await mediator.Send(new GetLocationByIdQuery(Id)));
            }).Produces(StatusCodes.Status200OK, typeof(LocationVm));

            routeBuilder.MapGet("/getAll", async (IMediator mediator) =>
            {
                return Results.Ok(await mediator.Send(new GetLocationListQuery()));
            }).Produces(StatusCodes.Status200OK, typeof(LocationVm));

            routeBuilder.MapPost("/", async (IMediator mediator, CreateLocationCommand createLocationCommand) =>
            {
                var user = await mediator.Send(createLocationCommand);

                return Results.Created(new Uri($"/api/location/", UriKind.Relative), user);
            }).Produces(statusCode: StatusCodes.Status201Created);

            return (RouteGroupBuilder)routeBuilder;
        
        }

    }
}
