using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserRentalCar.Application.Features.Locations.Commands.CreateLocation
{
    public record CreateLocationCommand(string Description):IRequest<Guid>;
   
}
