using BrowserRentalCar.Application.Features.Vehicles.Commands.CreateVehicle;
using BrowserRentalCar.Application.Features.Vehicles.Query;
using BrowserRentalCar.Domain.Dtos;
using MediatR;

namespace BrowserRentalCar.Api.ApiHandlers
{
    public static class VehicleApi
    {
        public static RouteGroupBuilder MapVehicle(this IEndpointRouteBuilder routeBuilder)
        {
            routeBuilder.MapGet("/getById", async (IMediator mediator,Guid Id)=>
            {
                return Results.Ok(await mediator.Send(new GetVehicleByIdQuery(Id)));
            }).Produces(StatusCodes.Status200OK, typeof(VehicleVm));

            routeBuilder.MapGet("/getAll", async (IMediator mediator) =>
            {
                return Results.Ok(await mediator.Send(new GetVehicleListQuery()));
            }).Produces(StatusCodes.Status200OK, typeof(VehicleVm));

            routeBuilder.MapPost("/", async (IMediator mediator, CreateVehicleCommand createVehicleCommand) =>
            {
                var user = await mediator.Send(createVehicleCommand);

                return Results.Created(new Uri($"/api/vehicle/", UriKind.Relative), user);
            }).Produces(statusCode: StatusCodes.Status201Created);

           // routeBuilder.MapPut("/", async (IMediator mediator, UpdateVehicleCommand))

            return (RouteGroupBuilder)routeBuilder;
        }
    }
}