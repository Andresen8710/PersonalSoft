namespace BrowserRentalCar.Domain.Entities
{
    public class TravelHistory : BaseDomainModel
    {
        public Guid VehicleId { get; set; }
        public Guid OriginId { get; set; }
        public Guid DestinationId { get; set; }
        public bool RouteComple { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual Location? OriginNavigation { get; set; }
        public virtual Location? DestinationNavigation { get; set; }
        public virtual Vehicle? VehicleNavigation { get; set; }
    }
}