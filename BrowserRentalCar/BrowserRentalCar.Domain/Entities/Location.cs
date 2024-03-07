using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserRentalCar.Domain.Entities
{
    public class Location:BaseDomainModel
    {
        public Location() 
        {
            OriginTravelHistories = new HashSet<TravelHistory>();
            DestinationTravelHistories = new HashSet<TravelHistory>();
        }
        public string?  Description { get; set; }

        public ICollection<TravelHistory> OriginTravelHistories { get; set; }
        public ICollection<TravelHistory> DestinationTravelHistories { get; set; }
    }
}
