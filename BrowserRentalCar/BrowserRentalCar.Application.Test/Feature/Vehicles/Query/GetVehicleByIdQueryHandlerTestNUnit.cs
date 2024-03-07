using AutoFixture;
using AutoMapper;
using BrowserRentalCar.Application.Features.Vehicles.Query;
using BrowserRentalCar.Application.Test.Mocks;
using BrowserRentalCar.Domain.Dtos;
using BrowserRentalCar.Domain.Entities;
using BrowserRentalCar.Infraestructure.Repositories;
using Moq;
using Shouldly;
using Xunit;

namespace BrowserRentalCar.Application.Test.Feature.Vehicles.Query
{
    public class GetVehicleByIdQueryHandlerTestNUnit
    {
        private readonly IMapper _mapper;
        private readonly Mock<VechicleRepository> _VehicleRepositoryMock;

        public GetVehicleByIdQueryHandlerTestNUnit()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Vehicle, VehicleVm>();
            });
            _mapper = mapperConfig.CreateMapper();

            _VehicleRepositoryMock = MockVehicleRepository.GetVehicleRepository();
        }

        [Fact]
        public async Task GetVehicleByIdQueryTestSuccess()
        {
            Guid vehicleId = Guid.Empty;
            var handler = new GetVehicleByIdQueryHandler(_VehicleRepositoryMock.Object, _mapper);
            //var vehicleId = fixture.Create<Guid>();
            //var request = new GetVehicleByIdQueryHandler(vehicleId);
            //var result= handler.Handle(request, CancellationToken.None);

            //result.ShouldBeOfType<List<VehicleVm>>();


            vehicleId = _VehicleRepositoryMock.Object.GetAllAsync().Result.FirstOrDefault().Id; // Generate a random vehicle ID
            var query = new GetVehicleByIdQuery(vehicleId);

            // Configure mock repository to return a mock vehicle
            var mockVehicle = new Vehicle { Id = vehicleId, /* Other properties */ };
            _VehicleRepositoryMock.Setup(r => r.GetByIdAsync(vehicleId)).ReturnsAsync(mockVehicle);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType<VehicleVm>();
        }
    }
}