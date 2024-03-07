namespace BrowserRentalCar.Domain.Dtos
{
    public class VehicleVm
    {
        public string Id { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Plate { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string? TravleId { get; set; }
    }
}