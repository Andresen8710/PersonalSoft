using BrowserRentalCar.Application.Contracts.Persistance;
using BrowserRentalCar.Infraestructure.Persistance;
using BrowserRentalCar.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BrowserRentalCar.Infraestructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BrowserRentalCarDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DB")));

            //services.AddDbContext<BrowserRentalCarDBContext>(options =>
            //    options.UseInMemoryDatabase("DB"));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IVehicleRepository, VechicleRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<ITravelHistoryRepository,TravelHistoryRepository>();
            return services;
        }
    }
}