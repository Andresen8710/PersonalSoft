namespace BrowserRentalCar.Domain.Dtos
{
    public record TravelHistoryVm()
    {
        public Guid Id { get; set; }
        public Guid VehicleId { get; set; }
        public Guid OriginId { get; set; }
        public Guid DestinationId { get; set; }
        public bool RouteComple { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}