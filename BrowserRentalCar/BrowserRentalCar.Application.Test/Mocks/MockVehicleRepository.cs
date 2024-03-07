using AutoFixture;
using BrowserRentalCar.Application.Contracts.Persistance;
using BrowserRentalCar.Domain.Entities;
using BrowserRentalCar.Infraestructure.Persistance;
using BrowserRentalCar.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;

namespace BrowserRentalCar.Application.Test.Mocks
{
    public static class MockVehicleRepository
    {
        public static Mock<VechicleRepository> GetVehicleRepository()
        {
            //creo la data de prueba
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());//omitir la recursion,referencia circular al generar data
            var vehicles = fixture.CreateMany<Vehicle>().ToList();

            vehicles.Add(fixture.Build<Vehicle>()
                .Create());

            //creacion bd en memoria
            var options = new DbContextOptionsBuilder<BrowserRentalCarDBContext>()
                .UseInMemoryDatabase(databaseName: $"BrowserRentalCarDB-{Guid.NewGuid()}")
                .Options;

            var browserRentalCarDBContextFake = new BrowserRentalCarDBContext(options);
            browserRentalCarDBContextFake.Vehicles!.AddRange(vehicles);
            browserRentalCarDBContextFake.SaveChanges();

            var mockRepository = new Mock<VechicleRepository>();
            
            return mockRepository;
        }
    }
}