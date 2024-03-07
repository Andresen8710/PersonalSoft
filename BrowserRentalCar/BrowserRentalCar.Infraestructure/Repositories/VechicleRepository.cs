using BrowserRentalCar.Application.Contracts.Persistance;
using BrowserRentalCar.Domain.Entities;
using BrowserRentalCar.Infraestructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserRentalCar.Infraestructure.Repositories
{
    public class VechicleRepository : RepositoryBase<Vehicle>, IVehicleRepository
    {
        public VechicleRepository(BrowserRentalCarDBContext context):base(context) { }

    }

  
}
