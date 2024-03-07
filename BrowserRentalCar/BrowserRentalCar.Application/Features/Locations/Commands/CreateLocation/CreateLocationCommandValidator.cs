using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserRentalCar.Application.Features.Locations.Commands.CreateLocation
{
    public class CreateLocationCommandValidator : AbstractValidator<CreateLocationCommand>
    {
        public CreateLocationCommandValidator() 
        {
            RuleFor(p => p.Description)
             .NotEmpty().WithMessage("{Description} no puede estar en blanco.")
             .NotNull()
             .MaximumLength(50).WithMessage("{Description} no puede exceder 50 caracteres.");
        }
    }
}
