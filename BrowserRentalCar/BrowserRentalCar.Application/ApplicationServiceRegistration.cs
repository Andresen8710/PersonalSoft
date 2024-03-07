using BrowserRentalCar.Application.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BrowserRentalCar.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //lee toda las clases que esten implementando el automaper y las va a inyectar
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //buscar todas las clases que esten referenciando a fluentvalidation y abstracvaliacion y la va a inyectar.
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            //inyecta el mediatr
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
           // services.AddMediatR(Assembly.GetExecutingAssembly());

            //inyecta el behaviors y excepciones
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnHandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}