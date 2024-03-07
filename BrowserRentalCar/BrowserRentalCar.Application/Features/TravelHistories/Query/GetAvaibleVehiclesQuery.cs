using AutoMapper;
using BrowserRentalCar.Application.Contracts.Persistance;
using BrowserRentalCar.Domain.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserRentalCar.Application.Features.TravelHistories.Query
{
    public record GetAvaibleVehiclesQuery(Guid originLocation, Guid destinationLocation) : IRequest<List<VehicleVm>>;

}
