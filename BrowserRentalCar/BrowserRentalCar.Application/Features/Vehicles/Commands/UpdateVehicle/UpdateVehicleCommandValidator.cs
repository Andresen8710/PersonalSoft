using FluentValidation;

namespace BrowserRentalCar.Application.Features.Vehicles.Commands.UpdateVehicle
{
    public class UpdateVehicleCommandValidator : AbstractValidator<UpdateVehicleCommand>
    {
        public UpdateVehicleCommandValidator()
        {
            RuleFor(p => p.Description)
                .NotNull()
                .WithMessage("{Description} no permite valores nulos."); ;

            RuleFor(p => p.Model)
                .NotNull()
                .WithMessage("{Model} no permite valores nulos.");

            RuleFor(p => p.Plate)
                .NotNull()
                .WithMessage("{Plate} no permite valores nulos.");
        }
    }
}