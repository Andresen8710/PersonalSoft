using AutoMapper;
using BrowserRentalCar.Application.Features.Locations.Commands.CreateLocation;
using BrowserRentalCar.Application.Features.TravelHistories.Commands;
using BrowserRentalCar.Application.Features.Vehicles.Commands.CreateVehicle;
using BrowserRentalCar.Domain.Dtos;
using BrowserRentalCar.Domain.Entities;

namespace BrowserRentalCar.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Vehicle, VehicleVm>();
            CreateMap<CreateVehicleCommand, Vehicle>();

            CreateMap<Location, LocationVm>();
            CreateMap<CreateLocationCommand, Location>();

            CreateMap<CreateTravelCommand, TravelHistory>();
            CreateMap<TravelHistory, TravelHistoryVm>();

        
        }
    }
}
