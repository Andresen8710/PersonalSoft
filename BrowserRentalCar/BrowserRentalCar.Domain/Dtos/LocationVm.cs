using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserRentalCar.Domain.Dtos
{
    public class LocationVm
    {
        public string Id { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
