using AutoMapper;
using BrowserRentalCar.Application.Contracts.Persistance;
using BrowserRentalCar.Application.Features.Vehicles.Commands.CreateVehicle;
using BrowserRentalCar.Application.Features.Vehicles.Query;
using BrowserRentalCar.Application.Test.Mocks;
using BrowserRentalCar.Domain.Dtos;
using BrowserRentalCar.Domain.Entities;
using Moq;
using Xunit;

namespace BrowserRentalCar.Application.Test.Feature.Vehicles.Command.CreateVehicle
{
    public class CreateVehicleCommandHandlerTestXUnit
    {
        //private readonly IMapper _mapper;
        //private readonly Mock<IVehicleRepository> _IVehicleRepositoryMock;

        //public CreateVehicleCommandHandlerTestXUnit()
        //{
        //    var mapperConfig = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<CreateVehicleCommand, Vehicle>();
        //    });

        //    _mapper = mapperConfig.CreateMapper();

        //    _IVehicleRepositoryMock = MockVehicleRepository.GetVehicleRepository();
        //}

        //[Fact]
        //public async Task GetVehicleListTestSuccess()
        //{
        //    var handler = new GetVehicleListHandler(_mapper,_IVehicleRepositoryMock.Object);
        //}

    }
}