using FluentValidation;

namespace BrowserRentalCar.Application.Features.Vehicles.Commands.CreateVehicle
{
    public class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
    {
        public CreateVehicleCommandValidator()
        {
            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{Description} no puede estar en blanco.")
                .NotNull()
                .MaximumLength(50).WithMessage("{Description} no puede exceder 50 caracteres.");
        }
    }
}