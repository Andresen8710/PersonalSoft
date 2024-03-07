using BrowserRentalCar.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace BrowserRentalCar.Infraestructure.Persistance
{
    public class BrowserRentalCarDbContextSeed
    {
        public static async Task SeedAsync(BrowserRentalCarDBContext context, ILogger<BrowserRentalCarDbContextSeed> logger)
        {
            if (!context.Vehicles.Any())
            {
                context.Vehicles!.AddRange(GetPreconfiguredVehicle());
                await context.SaveChangesAsync();
                logger.LogInformation("Estamos insertando nuevos Record al db { context}", typeof(BrowserRentalCarDBContext).Name);
            }
        }

        private static IEnumerable<Vehicle> GetPreconfiguredVehicle()
        {
            return new List<Vehicle>
            {
                new Vehicle {Description="Vehicle Sedan",Model="Sandero",Plate="XTZ34D",Brand="Renault"},
                new Vehicle {Description="Vehicle Hasback",Model="Mazda2",Plate="ADF67R",Brand="Mazda"}
            };
        }
    }
}